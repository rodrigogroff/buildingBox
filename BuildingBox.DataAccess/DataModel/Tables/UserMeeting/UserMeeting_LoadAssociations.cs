using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class UserMeeting
	{
		public UserMeeting LoadAssociations(BuildingBoxDB db)
		{
			sdtLog = GetDateTimeString(
				new System.DateTime((int)this.nuYear, 
									(int)fkMonth, 
									(int)nuDay, 
									(int)nuHour, 
									(int)nuMinute, 
									0));
			
			sfkState = new EnumMeetingState().Get((long)fkMeetingState).stName;
			sfkPlace = new EnumMeetingPlace().Get((long)fkMeetingPlace).stName;

			return this;
		}
	}
}
