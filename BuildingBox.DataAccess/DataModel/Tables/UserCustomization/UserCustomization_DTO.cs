using System.Collections.Generic;

namespace DataModel
{
	public partial class UserCustomization
	{
		public object anexedEntity;

		public string updateCommand,
						stName,
						sdtCreation,
						sfkContract,
						sfkCustomizationState,
						sdtUpdate;

		public long fkNewCustomizationState;

		public List<UserCustomizationEstimateLog> estimates = new List<UserCustomizationEstimateLog>();
		public List<UserCustomizationStateChange> stateChanges = new List<UserCustomizationStateChange>();
	}

	public partial class UserCustomizationEstimateLog
	{
		public string sdtLog,
						sfkUser;
	}

	public partial class UserCustomizationStateChange
	{
		public string sdtLog,
						sfkUser,
						sfkState;
	}
}
