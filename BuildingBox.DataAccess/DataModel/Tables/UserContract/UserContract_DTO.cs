using System.Collections.Generic;

namespace DataModel
{
	public partial class UserContract
	{
		public object anexedEntity;

		public string updateCommand,
						sdtCreation,
						sfkContinent,
						sfkContractState,
						sfkCountry,
						sfkCity;

		public List<UserContractState> states = new List<UserContractState>();
	}

	public partial class UserContractState
	{
		public string sdtLog,
						sfkUser,
						sfkContractState;
	}
}
