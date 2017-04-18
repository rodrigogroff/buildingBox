using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class ContractState
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumContractState
	{
		public List<ContractState> lst = new List<ContractState>();

		public const long Pending = 1,
							Setup = 2,
							Testing = 3,
							Ready = 4;

		public EnumContractState()
		{
			lst.Add(new ContractState() { id = Pending, stName = "Pending" });
			lst.Add(new ContractState() { id = Setup, stName = "Setup" });
			lst.Add(new ContractState() { id = Testing, stName = "Testing" });
			lst.Add(new ContractState() { id = Ready, stName = "Ready" });
		}

		public ContractState Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
