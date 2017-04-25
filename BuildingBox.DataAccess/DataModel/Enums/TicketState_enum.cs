using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class TicketState
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumTicketState
	{
		public List<TicketState> lst = new List<TicketState>();

		public const long	Pending = 1,
							Analysis = 2,
							Answered = 3,
							Closed = 4,
							Cancelled = 5;

		public EnumTicketState()
		{
			lst.Add(new TicketState { id = Pending, stName = "Pending" });
			lst.Add(new TicketState { id = Analysis, stName = "Analysis" });
			lst.Add(new TicketState { id = Answered, stName = "Answered" });
			lst.Add(new TicketState { id = Closed, stName = "Closed" });
			lst.Add(new TicketState { id = Cancelled, stName = "Cancelled" });
		}

		public TicketState Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
