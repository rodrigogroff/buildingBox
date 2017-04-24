using LinqToDB;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace DataModel
{
	public partial class UserMeeting
	{
		public bool Update(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();
			
			switch (updateCommand)
			{
				case "entity":
					{						
						db.Update(this);

						LoadAssociations(db);

						break;
					}
			}

			return true;
		}
	}
}
