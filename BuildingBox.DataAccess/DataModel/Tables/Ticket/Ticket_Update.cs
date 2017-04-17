using LinqToDB;
using Newtonsoft.Json;
using System;

namespace DataModel
{
	public partial class Ticket
	{
		public bool Update(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			switch (updateCommand)
			{
				case "entity":
					{
						dtLog = DateTime.Now;
						
						db.Update(this);

						break;
					}

				case "newMessage":
					{
						dtLog = DateTime.Now;

						var ent = JsonConvert.DeserializeObject<TicketMessage>(anexedEntity.ToString());

						ent.fkTicket = this.id;
						ent.dtLog = dtLog;
						ent.fkUser = user.id;

						db.Insert(ent);

						db.Update(this);

						LoadAssociations(db);

						break;
					}

				case "newAttendance":
					{
						var ent = JsonConvert.DeserializeObject<TicketWorkFlow>(anexedEntity.ToString());

						ent.fkTicket = this.id;
						ent.dtLog = dtLog;
						ent.fkUser = user.id;
						ent.fkOldState = this.fkTicketState;

						db.Insert(ent);

						fkTicketState = ent.fkNewState;
						dtLog = DateTime.Now;

						db.Update(this);

						LoadAssociations(db);

						break;
					}
			}

			return true;
		}
	}
}
