using System;
using System.Threading;
using LinqToDB;

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

		public string GetBillId()
		{
			var ret = "";
			var stProtocolFormat = "999999999";

			if (stProtocolFormat != null)
				foreach (var i in stProtocolFormat)
					if (Char.IsDigit(i))
						ret += RandomNumber(0, 9).ToString();
					else
						ret += i;

			return this.id.ToString().PadLeft(3,'0') + ret;
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

		public void InsertContractDetails(BuildingBoxDB db, long? bill_id, long fkContractType)
		{
			switch (fkContractType)
			{
				case EnumContractType.Economy:
					{
						db.Insert(new BillDetail
						{
							fkUserContractBill = bill_id,
							nuValue = 100,
							stItem = ""
						});
						break;
					}
			}			
		}
	}
}
