using System;
using System.Threading;

namespace DataModel
{
	public partial class Ticket
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
			var stProtocolFormat = "9999.9999";

			if (stProtocolFormat != null)
				foreach (var i in stProtocolFormat)
					if (Char.IsDigit(i))
						ret += RandomNumber(0, 9).ToString();
					else
						ret += i;

			return ret;
		}
	}
}
