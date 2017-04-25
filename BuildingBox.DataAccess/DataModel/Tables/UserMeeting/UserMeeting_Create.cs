using LinqToDB;
using System;

namespace DataModel
{
	public partial class UserMeeting
	{
		public bool Create(BuildingBoxDB db, ref string resp)
		{
			// validate time
			try
			{
				new System.DateTime((int)this.nuYear,(int)fkMonth,(int)nuDay,(int)nuHour,(int)nuMinute,0);
			}
			catch (SystemException ex)
			{
				resp = "Invalid date!";
				return false;
			}

			var user = db.GetCurrentUser();

			fkUser = user.id;
			fkMeetingState = EnumMeetingState.PendingConfirmation;
			
			id = Convert.ToInt64(db.InsertWithIdentity(this));
			
			db.Insert(new UserMeetingSchedule
			{
				dtLog = DateTime.Now,
				fkMeeting = this.id,
				fkUser = user.id,
				fkState = this.fkMeetingState,
				stDate = GetDateTimeString(new System.DateTime((int)this.nuYear,(int)fkMonth,(int)nuDay,(int)nuHour,(int)nuMinute,0))
			});

			LoadAssociations(db);

			return true;
		}
	}
}
