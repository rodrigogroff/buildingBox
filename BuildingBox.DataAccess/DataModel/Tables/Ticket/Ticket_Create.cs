using LinqToDB;
using System;

namespace DataModel
{
	public partial class Ticket
	{
		public bool Create(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			fkTicketState = EnumTicketState.Analysis;
			dtCreation = DateTime.Now;
			fkUserOpen = user.id;
			dtLog = DateTime.Now;

			id = Convert.ToInt64(db.InsertWithIdentity(this));

			return true;
		}
	}
}
