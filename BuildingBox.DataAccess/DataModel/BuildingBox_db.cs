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
	}
}
