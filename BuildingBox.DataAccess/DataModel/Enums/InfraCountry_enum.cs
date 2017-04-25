using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class InfraCountry
	{
		public long id { get; set; }
		public long fkContinent { get; set; }
		public string stName { get; set; }
	}

	public class EnumInfraCountry
	{
		public List<InfraCountry> lst = new List<InfraCountry>();

		public const long   UnitedStates = 1,
							Germany = 2,
							France = 3,
							Netherlands = 4,
							UnitedKingdom = 5,
							Australia = 6,
							Singapore = 7,
							Japan = 8;

		public EnumInfraCountry()
		{
			lst.Add(new InfraCountry { id = UnitedStates, fkContinent = EnumInfraContinent.America, stName = "United States" });

			lst.Add(new InfraCountry { id = Germany, fkContinent = EnumInfraContinent.Europe, stName = "Germany" });
			lst.Add(new InfraCountry { id = France, fkContinent = EnumInfraContinent.Europe, stName = "France" });
			lst.Add(new InfraCountry { id = Netherlands, fkContinent = EnumInfraContinent.Europe, stName = "Netherlands" });
			lst.Add(new InfraCountry { id = UnitedKingdom, fkContinent = EnumInfraContinent.Europe, stName = "United Kingdom" });

			lst.Add(new InfraCountry { id = Australia, fkContinent = EnumInfraContinent.Australia, stName = "Australia" });

			lst.Add(new InfraCountry { id = Singapore, fkContinent = EnumInfraContinent.Asia, stName = "Singapore" });
			lst.Add(new InfraCountry { id = Japan, fkContinent = EnumInfraContinent.Asia, stName = "Japan" });
		}

		public InfraCountry Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
