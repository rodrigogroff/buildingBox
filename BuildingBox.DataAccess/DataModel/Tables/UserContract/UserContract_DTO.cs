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
	}

	public partial class UserContractState
	{
		public string sdtLog,
						sfkUser,
						sfkContractState;
	}
}
