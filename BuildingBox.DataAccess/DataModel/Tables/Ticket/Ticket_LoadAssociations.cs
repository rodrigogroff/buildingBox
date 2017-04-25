using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class Ticket
	{
		EnumTicketState ets = new EnumTicketState();

		public Ticket LoadAssociations(BuildingBoxDB db)
		{
			var user = db.GetCurrentUser();
			var contract = db.UserContract(fkContract);			

			sfkUser = db.User(this.fkUserOpen).stContactEmail;
			fkClientType = user.fkClientType;

			sfkState = ets.Get((long)fkTicketState).stName;
			sdtCreation = GetDateTimeString(dtCreation);
			sdtLog = GetDateTimeString(dtLog);

			sfkContract = contract.stProtocol + " - " + new EnumInfraCity().Get((long)contract.fkCity).stName;

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
				item.sfkUser = db.User(item.fkUser).stContactEmail;
			}

			return lst;
		}

		List<TicketWorkFlow> LoadAttendances(BuildingBoxDB db)
		{
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

				item.sfkOldState = ets.Get((long)item.fkOldState).stName;
				item.sfkNewState = ets.Get((long)item.fkNewState).stName;
			}

			return lst;
		}
	}
}
