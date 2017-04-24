using LinqToDB;
using System;

namespace DataModel
{
	public partial class UserMeeting
	{
		public bool Create(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			fkUser = user.id;
			fkMeetingState = EnumMeetingState.PendingConfirmation;
			
			id = Convert.ToInt64(db.InsertWithIdentity(this));

			return true;
		}
	}
}
