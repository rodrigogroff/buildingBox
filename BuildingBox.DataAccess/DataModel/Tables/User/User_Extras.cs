using System;
using System.Threading;

namespace DataModel
{
	public partial class User
	{
		Random random = new Random();

		int RandomNumber(int min, int max)
		{
			Thread.Sleep(1);
			return random.Next(min, max);
		}

		public string GetRandomString(int size)
		{
			var ret = "";

			for(int t=0;t < size;++t)
				ret += RandomNumber(0, 9).ToString();
			
			return ret;
		}
	}
}
