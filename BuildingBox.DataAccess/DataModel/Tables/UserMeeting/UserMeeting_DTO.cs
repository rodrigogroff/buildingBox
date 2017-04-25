﻿using System.Collections.Generic;

namespace DataModel
{
	public partial class UserMeeting
	{
		public object anexedEntity;

		public string updateCommand,
						sdtLog,
						sfkState,
						sfkGMT,
						sfkPlace;

		public long? fkNewMeetingState;

		public List<UserMeetingSchedule> schedules = new List<UserMeetingSchedule>();
		public List<UserMeetingSchedule> stateChanges = new List<UserMeetingSchedule>();
	}

	public partial class UserMeetingSchedule
	{
		public string sdtLog,
						sfkUser,
						sfkState;
	}
}
