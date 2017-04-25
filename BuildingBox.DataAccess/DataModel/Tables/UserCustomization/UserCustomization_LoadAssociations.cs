using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class UserCustomization
	{
		public UserCustomization LoadAssociations(BuildingBoxDB db)
		{
			var user = db.GetCurrentUser();

			sfkUser = db.User(this.fkUser).stContactEmail;
			fkClientType = user.fkClientType;

			var contract = db.UserContract(fkContract);

			sdtCreation = GetDateTimeString(dtCreation);
			sdtUpdate = GetDateTimeString(dtUpdate);
			sdtEstimativeApproval = GetDateTimeString(dtEstimativeApproval);
			sdtFinalApproval = GetDateTimeString(dtFinalApproval);

			sfkContract = contract.stProtocol + " - " + new EnumInfraCity().Get((long)contract.fkCity).stName;

			if (fkCustomizationState > 0)
				sfkCustomizationState = new EnumCustomizationState().Get((long)this.fkCustomizationState).stName;

			stName = stProtocol + " - " + stVersion;

			estimates = LoadEstimates(db);
			stateChanges = LoadStateChanges(db);

			return this;
		}

		List<UserCustomizationEstimateLog> LoadEstimates(BuildingBoxDB db)
		{
			var lst = (from e in db.UserCustomizationEstimateLogs
					   where e.fkCustomization == this.id
					   select e).
					   ToList();

			foreach (var item in lst)
			{
				item.sdtLog = GetDateTimeString(item.dtLog);
				item.sfkUser = db.User(item.fkUser).stContactEmail;
			}

			return lst;
		}

		List<UserCustomizationStateChange> LoadStateChanges(BuildingBoxDB db)
		{
			var lst = (from e in db.UserCustomizationStateChanges
					   where e.fkCustomization == this.id
					   select e).
					   OrderByDescending (y=> y.id).
					   ToList();

			foreach (var item in lst)
			{
				item.sdtLog = GetDateTimeString(item.dtLog);
				item.sfkUser = db.User(item.fkUser).stContactEmail;
				item.sfkState = new EnumCustomizationState().Get((long)item.fkState).stName;
			}

			return lst;
		}
	}
}
