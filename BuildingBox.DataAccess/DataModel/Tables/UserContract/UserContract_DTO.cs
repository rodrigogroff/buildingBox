using System.Collections.Generic;

namespace DataModel
{
	public partial class UserContract
	{
		public object anexedEntity;

		public string sfkUser;
		public long? fkClientType;

		public string updateCommand,
						stName,
						sdtCreation,
						sfkContinent,
						sfkContractState,
						sfkCountry,
						sfkCity,
						snuContractValue;

		public List<UserContractState> states = new List<UserContractState>();
		public List<UserContractBill> pendingBills = new List<UserContractBill>();
	}

	public partial class UserContractState
	{
		public string sdtLog,
						sfkUser,
						sfkContractState;
	}

	public partial class UserContractBill
	{
		public string sdtLog,
						snuMonth,
						snuValue;

	}
}
