using LinqToDB;
using Newtonsoft.Json;
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
						db.Update(this);

						break;
					}
			}

			return true;
		}
	}
}
