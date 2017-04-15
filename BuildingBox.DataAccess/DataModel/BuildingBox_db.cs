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
	}
}
