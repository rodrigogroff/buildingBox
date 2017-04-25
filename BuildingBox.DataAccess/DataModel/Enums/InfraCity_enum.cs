using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class InfraCity
	{
		public long id { get; set; }
		public long fkCountry { get; set; }
		public string stName { get; set; }
	}

	public class EnumInfraCity
	{
		public List<InfraCity> lst = new List<InfraCity>();

		public EnumInfraCity()
		{
			int t = 1;
			
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedStates, stName = "Dallas" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedStates, stName = "Miami" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedStates, stName = "Silicon Valley" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedStates, stName = "Atlanta" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedStates, stName = "Chicago" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedStates, stName = "Los-Angeles" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedStates, stName = "New York (NJ)" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedStates, stName = "Seattle" });

			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.Germany, stName = "Frankfurt" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.France, stName = "Paris" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.Netherlands, stName = "Amsterdam" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.UnitedKingdom, stName = "London" });

			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.Australia, stName = "Sydney" });

			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.Singapore, stName = "Singapore" });
			lst.Add(new InfraCity { id = t++, fkCountry = EnumInfraCountry.Japan, stName = "Tokyo" });
		}

		public InfraCity Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
