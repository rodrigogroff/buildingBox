using LinqToDB;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace DataModel
{
	public partial class UserContract
	{
		public bool Update(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();
			
			switch (updateCommand)
			{
				case "entity":
					{
						var oldContract = db.UserContract(this.id);
						
						if (oldContract.fkContractState != this.fkContractState)
						{
							db.Insert(new UserContractState
							{
								fkUser = user.id,
								dtLog = DateTime.Now,
								fkContract = this.id,
								fkContractState = this.fkContractState
							});
						}

						if (oldContract.fkContractType != this.fkContractType)
						{
							this.fkContractState = EnumContractState.PendingUpgradeSetup;

							db.Insert(new UserContractState
							{
								fkUser = user.id,
								dtLog = DateTime.Now,
								fkContract = this.id,
								fkContractState = this.fkContractState
							});
						}

						db.Update(this);

						LoadAssociations(db);

						break;
					}
			}

			return true;
		}
	}
}
