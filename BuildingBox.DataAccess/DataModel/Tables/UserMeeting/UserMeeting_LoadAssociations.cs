using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class UserMeeting
	{
		EnumMeetingState ems = new EnumMeetingState();
		EnumMeetingPlace emp = new EnumMeetingPlace();

		public UserMeeting LoadAssociations(BuildingBoxDB db)
		{
			sdtLog = GetDateTimeString(
				new System.DateTime((int)this.nuYear, 
									(int)fkMonth, 
									(int)nuDay, 
									(int)nuHour, 
									(int)nuMinute, 
									0));
			
			sfkState = ems.Get((long)fkMeetingState).stName;
			sfkPlace = emp.Get((long)fkMeetingPlace).stName;
			sfkGMT = new EnumGMT().Get((long)fkGMT).stName;

			schedules = LoadSchedules(db);
			stateChanges = LoadStateChanges(db);

			return this;
		}

		List<UserMeetingSchedule> LoadSchedules(BuildingBoxDB db)
		{
			var lst = (from e in db.UserMeetingSchedules
					   where e.fkMeeting == this.id
					   select e).
					OrderByDescending(y => y.id).
					ToList();
			
			foreach (var item in lst)
			{
				item.sdtLog = GetDateTimeString(item.dtLog);
				item.sfkUser = db.User(item.fkUser).stContactEmail;
				item.sfkState = ems.Get((long)item.fkState).stName;
			}

			return lst;
		}

		List<UserMeetingSchedule> LoadStateChanges(BuildingBoxDB db)
		{
			var ret = new List<UserMeetingSchedule>();

			var lst = ( from e in db.UserMeetingSchedules
					    where e.fkMeeting == this.id
					    select e).
						OrderByDescending(y => y.id).
						ToList();

			long? lastState = null;

			foreach (var item in lst)
			{
				item.sdtLog = GetDateTimeString(item.dtLog);
				item.sfkUser = db.User(item.fkUser).stContactEmail;
				item.sfkState = ems.Get((long)item.fkState).stName;
				
				if (item.fkState != lastState)
					ret.Add(item);

				lastState = item.fkState;
			}

			return ret;
		}
	}
}
