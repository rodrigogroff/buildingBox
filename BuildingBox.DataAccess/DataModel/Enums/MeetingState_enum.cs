using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class MeetingState
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumMeetingState
	{
		public List<MeetingState> lst = new List<MeetingState>();

		public const long PendingConfirmation = 1,
							Confirmed = 2,
							Done = 3,
							Cancelled = 4;

		public EnumMeetingState()
		{
			lst.Add(new MeetingState() { id = PendingConfirmation, stName = "Pending Confirmation" });
			lst.Add(new MeetingState() { id = Confirmed, stName = "Confirmed" });
			lst.Add(new MeetingState() { id = Done, stName = "Done" });
			lst.Add(new MeetingState() { id = Cancelled, stName = "Cancelled" });
		}

		public MeetingState Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
