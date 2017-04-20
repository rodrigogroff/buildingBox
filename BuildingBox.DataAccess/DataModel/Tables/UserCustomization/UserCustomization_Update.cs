using LinqToDB;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace DataModel
{
	public partial class UserCustomization
	{
		public bool Update(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();
			
			switch (updateCommand)
			{
				case "entity":
					{
						this.dtUpdate = DateTime.Now;

						db.Update(this);

						LoadAssociations(db);

						break;
					}
			}

			return true;
		}
	}
}
