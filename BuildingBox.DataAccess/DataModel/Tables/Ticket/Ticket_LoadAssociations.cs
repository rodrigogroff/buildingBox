using LinqToDB;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DataModel
{
	public partial class Ticket
	{
		public Ticket LoadAssociations(BuildingBoxDB db)
		{
			var enumMonth = new EnumMonth();
			var enumTicketState = new EnumTicketState();

			sfkState = enumTicketState.Get((long)fkTicketState).stName;
			sdtCreation = enumMonth.Get((long)dtCreation.Value.Month).stName + " " + dtCreation.Value.Day + ", " + dtCreation.Value.Year;
			sdtLog = enumMonth.Get((long)dtLog.Value.Month).stName + " " + dtLog.Value.Day + ", " + dtLog.Value.Year;

			return this;
		}
	}
}
