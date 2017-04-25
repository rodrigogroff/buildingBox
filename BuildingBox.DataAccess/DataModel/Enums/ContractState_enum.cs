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

		public const long PendingStartSetup = 1,
							InitialSetup = 20,
							PendingUpgradeSetup = 30,
							UpgradeSetup = 40,
							SolutionReady = 50,
							Cancelled = 100;

		public EnumContractState()
		{
			lst.Add(new ContractState { id = PendingStartSetup, stName = "Pending (first setup)" });
			lst.Add(new ContractState { id = InitialSetup, stName = "Initial Setup" });
			lst.Add(new ContractState { id = PendingUpgradeSetup, stName = "Pending (plan upgrade)" });
			lst.Add(new ContractState { id = UpgradeSetup, stName = "Testing" });
			lst.Add(new ContractState { id = SolutionReady, stName = "Solution Ready" });
			lst.Add(new ContractState { id = Cancelled, stName = "Cancelled" });
		}

		public ContractState Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
