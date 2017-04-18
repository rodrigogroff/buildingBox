using LinqToDB;
using System;
using System.Linq;

namespace DataModel
{
	public partial class UserContract
	{
		public bool Create(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			fkUser = user.id;
			dtCreation = DateTime.Now;
			stProtocol = GetProtocol();
			fkContractState = EnumContractState.Pending;

			id = Convert.ToInt64(db.InsertWithIdentity(this));

			return true;
		}
	}
}
