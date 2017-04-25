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
			sfkGMT = new EnumGMT().Get((long)fkGMT).stName;

			schedules = LoadSchedules(db);

			return this;
		}

		List<UserMeetingSchedule> LoadSchedules(BuildingBoxDB db)
		{
			var lst = (from e in db.UserMeetingSchedules
					   where e.fkMeeting == this.id
					   select e).
					OrderByDescending(y => y.id).
					ToList();

			var ems = new EnumMeetingState();

			foreach (var item in lst)
			{
				item.sdtLog = GetDateTimeString(item.dtLog);
				item.sfkUser = db.User(item.fkUser).stContactEmail;
				item.sfkState = ems.Get((long)item.fkState).stName;
			}

			return lst;
		}
	}
}
