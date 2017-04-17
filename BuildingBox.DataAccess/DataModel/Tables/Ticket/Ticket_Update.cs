using LinqToDB;
using System;

namespace DataModel
{
	public partial class Ticket
	{
		public bool Update(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			switch (updateCommand)
			{
				case "entity":
					{
						dtLog = DateTime.Now;
						
						db.Update(this);

						break;
					}
			}

			return true;
		}
	}
}
