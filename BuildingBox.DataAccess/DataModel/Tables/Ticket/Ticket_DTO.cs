using System.Collections.Generic;

namespace DataModel
{
	public partial class Ticket
	{
		public object anexedEntity;

		public string updateCommand,
						sfkContract,
						sfkState,
						sdtCreation,
						sdtLog;

		public string sfkUser;
		public long? fkClientType;

		public List<TicketMessage> messages;
		public List<TicketWorkFlow> attendances;
	}

	public partial class TicketMessage
	{
		public string sdtLog, 
					  sfkUser;
	}

	public partial class TicketWorkFlow
	{
		public string sdtLog,
						sfkUser,
						sfkOldState,
						sfkNewState;
	}
}
