using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class InfraContinent
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumInfraContinent
	{
		public List<InfraContinent> lst = new List<InfraContinent>();

		public const long America = 1,
							Europe = 2, 
							Australia = 3, 
							Asia = 4;

		public EnumInfraContinent()
		{
			lst.Add(new InfraContinent { id = America, stName = "America" });
			lst.Add(new InfraContinent { id = Europe, stName = "Europe" });
			lst.Add(new InfraContinent { id = Australia, stName = "Australia" });
			lst.Add(new InfraContinent { id = Asia, stName = "Asia" });
		}

		public InfraContinent Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
