using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class User
	{
		public User LoadAssociations(BuildingBoxDB db)
		{
			contracts = LoadContracts(db);

			return this;
		}

		List<UserContract> LoadContracts(BuildingBoxDB db)
		{
			var ecity = new EnumInfraCity();
			var ecountry = new EnumInfraCountry();
			var econtinent = new EnumInfraContinent();

			var lst = (from e in db.UserContracts
					   where e.fkUser == this.id
					   select e).
					   ToList();
			
			foreach (var item in lst)
			{
				item.sfkCity = ecity.Get((long)item.fkCity).stName;
				item.sfkCountry = ecountry.Get((long)item.fkCountry).stName;
				item.sfkContinent = econtinent.Get((long)item.fkContinent).stName;
			}

			return lst;
		}
	}
}
