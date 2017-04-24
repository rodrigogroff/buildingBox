using System.Collections;
using System.Linq;
using System.Threading;

namespace DataModel
{
	public partial class BuildingBoxDB
	{				
		public User currentUser = null;

		public User GetCurrentUser()
		{
			if (currentUser == null)
				currentUser = (from ne in this.Users
							   where ne.stContactEmail.ToUpper() == Thread.CurrentPrincipal.Identity.Name.ToUpper()
							   select ne).FirstOrDefault();

			return currentUser;
		}

		// ----------------------------------
		// Tables by Id (using cache)
		// ----------------------------------

		Hashtable Cache = new Hashtable();

		public User User(long? id)
		{
			if (id == null) return null;
			var tag = "User" + id; var ret = Cache[tag] as User;
			if (ret == null) { ret = Users.Find((long)id); Cache[tag] = ret; }
			return ret;
		}

		public UserMeeting UserMeeting(long? id)
		{
			if (id == null) return null;
			var tag = "UserMeeting" + id; var ret = Cache[tag] as UserMeeting;
			if (ret == null) { ret = UserMeetings.Find((long)id); Cache[tag] = ret; }
			return ret;
		}

		public Ticket Ticket(long? id)
		{
			if (id == null) return null;
			var tag = "Ticket" + id; var ret = Cache[tag] as Ticket;
			if (ret == null) { ret = Tickets.Find((long)id); Cache[tag] = ret; }
			return ret;
		}

		public UserContract UserContract(long? id)
		{
			if (id == null) return null;
			var tag = "UserContract" + id; var ret = Cache[tag] as UserContract;
			if (ret == null) { ret = UserContracts.Find((long)id); Cache[tag] = ret; }
			return ret;
		}

		public UserCustomization UserCustomization(long? id)
		{
			if (id == null) return null;
			var tag = "UserCustomization" + id; var ret = Cache[tag] as UserCustomization;
			if (ret == null) { ret = UserCustomizations.Find((long)id); Cache[tag] = ret; }
			return ret;
		}
	}
}
