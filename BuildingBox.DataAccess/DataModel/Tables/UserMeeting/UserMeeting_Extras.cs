using System;
using System.Threading;

namespace DataModel
{
	public partial class UserMeeting
	{
		public string GetDateTimeString(DateTime? _dt)
		{
			if (_dt == null)
				return "";

			var enumMonth = new EnumMonth();

			return enumMonth.Get((long)_dt.Value.Month).stName + " " +
				_dt.Value.Day + ", " +
				_dt.Value.Year + " " +
				_dt.Value.Hour.ToString().PadLeft(2, '0') + ":" +
				_dt.Value.Minute.ToString().PadLeft(2, '0');
		}
	}
}
