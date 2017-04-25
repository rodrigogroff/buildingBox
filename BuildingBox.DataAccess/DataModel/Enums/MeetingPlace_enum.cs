using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class MeetingPlace
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumMeetingPlace
	{
		public List<MeetingPlace> lst = new List<MeetingPlace>();

		public const long Internet = 1,
							Local = 2;

		public EnumMeetingPlace()
		{
			lst.Add(new MeetingPlace() { id = Internet, stName = "Internet" });
			lst.Add(new MeetingPlace() { id = Local, stName = "Local / Premises" });
		}

		public MeetingPlace Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
