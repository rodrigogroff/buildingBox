using System.Collections.Generic;

namespace DataModel
{
	public partial class UserMeeting
	{
		public object anexedEntity;

		public string sfkUser;
		public long? fkClientType;

		public string updateCommand,
						sdtLog,
						sfkState,
						sfkGMT,
						sfkPlace;

		public long? fkNewMeetingState;

		public List<UserMeetingSchedule> schedules = new List<UserMeetingSchedule>();
		public List<UserMeetingSchedule> stateChanges = new List<UserMeetingSchedule>();
		public List<UserMeetingPerson> people = new List<UserMeetingPerson>();
	}

	public partial class UserMeetingSchedule
	{
		public string sdtLog,
						sfkUser,
						sfkState;
	}
}
