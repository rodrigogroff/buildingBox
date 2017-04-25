using System;
using System.Threading;

namespace DataModel
{
	public partial class UserContract
	{
		Random random = new Random();

		int RandomNumber(int min, int max)
		{
			Thread.Sleep(1);
			return random.Next(min, max);
		}

		public string GetProtocol()
		{
			var ret = "";
			var stProtocolFormat = "999";

			if (stProtocolFormat != null)
				foreach (var i in stProtocolFormat)
					if (Char.IsDigit(i))
						ret += RandomNumber(0, 9).ToString();
					else
						ret += i;

			return ret;
		}

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

		public string GetMoneyString(long? val)
		{
			if (val == null)
				return "0,00";

			var ret = val.ToString();

			if (ret.Length <= 2) return "0," + ret;			
			if (ret.Length >= 2) ret = ret.Insert ( ret.Length - 2, ",");
			if (ret.Length >= 7) ret = ret.Insert(ret.Length - 6, ".");

			return ret;
		}
	}
}
