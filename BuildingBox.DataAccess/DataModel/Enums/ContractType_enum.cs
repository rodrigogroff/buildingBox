using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class ContractType
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumContractType
	{
		public List<ContractType> lst = new List<ContractType>();

		public const long Economy = 1,
							Standard = 2,
							Advanced = 3,
							Premium = 4,
							Master = 5;

		public EnumContractType()
		{
			lst.Add(new ContractType { id = Economy, stName = "Economy (up to 30 users)" });
			lst.Add(new ContractType { id = Standard, stName = "Standard (up to 90 users)" });
			lst.Add(new ContractType { id = Advanced, stName = "Advanced (up to 170 users)" });
			lst.Add(new ContractType { id = Premium, stName = "Premium (up to 350 users)" });
			lst.Add(new ContractType { id = Master, stName = "Master (up to 800 users)" });
		}

		public ContractType Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
