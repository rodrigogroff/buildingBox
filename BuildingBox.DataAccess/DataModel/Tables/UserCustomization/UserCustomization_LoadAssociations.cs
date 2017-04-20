using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class UserCustomization
	{
		public UserCustomization LoadAssociations(BuildingBoxDB db)
		{
			var contract = db.UserContract(fkContract);

			sdtCreation = GetDateTimeString(dtCreation);
			sdtUpdate = GetDateTimeString(dtUpdate);
			sfkContract = contract.stProtocol + " - " + new EnumInfraCity().Get((long)contract.fkCity).stName;
			sfkCustomizationState = new EnumCustomizationState().Get((long)this.fkCustomizationState).stName;

			stName = stProtocol + " - " + stVersion;

			return this;
		}
	}
}
