using LinqToDB;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace DataModel
{
	public partial class UserMeeting
	{
		public bool Update(BuildingBoxDB db, ref string resp)
		{
			// validate time
			try
			{
				new System.DateTime((int)this.nuYear, (int)fkMonth, (int)nuDay, (int)nuHour, (int)nuMinute, 0);
			}
			catch (SystemException ex)
			{
				resp = "Invalid date!";
				return false;
			}

			var user = db.GetCurrentUser();
			
			switch (updateCommand)
			{
				case "entity":
					{
						var oldMeeting = db.UserMeeting(id);

						fkMeetingState = fkNewMeetingState;

						if (oldMeeting.fkGMT != this.fkGMT ||
							oldMeeting.nuYear != this.nuYear ||
							oldMeeting.fkMonth != this.fkMonth ||
							oldMeeting.nuDay != this.nuDay ||
							oldMeeting.nuHour != this.nuHour ||
							oldMeeting.nuMinute != this.nuMinute ||
							oldMeeting.fkMeetingState != fkMeetingState)
						{
							db.Insert(new UserMeetingSchedule
							{
								dtLog = DateTime.Now,
								fkMeeting = this.id,
								fkUser = user.id,
								fkState = this.fkMeetingState,
								stDate = GetDateTimeString(
									new System.DateTime((int)this.nuYear,
										(int)fkMonth,
										(int)nuDay,
										(int)nuHour,
										(int)nuMinute,
								0))
							});
						}
						
						db.Update(this);

						LoadAssociations(db);

						break;
					}
			}

			return true;
		}
	}
}
