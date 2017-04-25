using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class ContractValue
	{
		public long id { get; set; }
		public string stName { get; set; }
		public long nuValue { get; set; }
	}

	public class EnumContractValue
	{
		public List<ContractValue> lst = new List<ContractValue>();

		public const long Economy = 1,
							Standard = 2,
							Advanced = 3,
							Premium = 4,
							Master = 5;

		public EnumContractValue()
		{
			lst.Add(new ContractValue { id = Economy, stName = "Economy", nuValue = 14200 });
			lst.Add(new ContractValue { id = Standard, stName = "Standard", nuValue = 19400 });
			lst.Add(new ContractValue { id = Advanced, stName = "Advanced", nuValue = 56600 });
			lst.Add(new ContractValue { id = Premium, stName = "Premium", nuValue = 87400 });
			lst.Add(new ContractValue { id = Master, stName = "Master", nuValue = 129000 });
		}

		public ContractValue Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
