using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class Ticket
	{
		public Ticket LoadAssociations(BuildingBoxDB db)
		{
			sfkState = new EnumTicketState().Get((long)fkTicketState).stName;
			sdtCreation = GetDateTimeString(dtCreation);
			sdtLog = GetDateTimeString(dtLog);

			messages = LoadMessages(db);
			attendances = LoadAttendances(db);

			return this;
		}

		List<TicketMessage> LoadMessages(BuildingBoxDB db)
		{
			var lst = (from e in db.TicketMessages
					where e.fkTicket == this.id
					select e).
					OrderByDescending(y=>y.id).
					ToList();

			foreach (var item in lst)
			{
				item.sdtLog = GetDateTimeString(item.dtLog);
				item.sfkUser = db.User(item.fkUser).stClientName;

				if (item.sfkUser.Length > 10)
					item.sfkUser = item.sfkUser.Substring(0, 10) + "...";
			}

			return lst;
		}

		List<TicketWorkFlow> LoadAttendances(BuildingBoxDB db)
		{
			var ts = new EnumTicketState();

			var lst = (from e in db.TicketWorkFlows
					   where e.fkTicket == this.id
					   select e).
					OrderByDescending(y => y.id).
					ToList();

			foreach (var item in lst)
			{
				item.sdtLog = GetDateTimeString(item.dtLog);
				item.sfkUser = db.User(item.fkUser).stClientName;

				if (item.sfkUser.Length > 10)
					item.sfkUser = item.sfkUser.Substring(0, 10) + "...";

				item.sfkOldState = ts.Get((long)item.fkOldState).stName;
				item.sfkNewState = ts.Get((long)item.fkNewState).stName;
			}

			return lst;
		}
	}
}
