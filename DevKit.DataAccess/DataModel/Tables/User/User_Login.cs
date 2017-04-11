using System.Linq;

namespace DataModel
{
	public partial class User
	{
		public User Login(BuildingBoxDB db, string login, string password)
		{
			var user = (from e in db.Users
						where e.stContactEmail.ToUpper() == login.ToUpper()
						where e.stPassword.ToUpper() == password.ToUpper()
						select e).
						FirstOrDefault();

			if (user != null)
			{
				return user;
			}

			return null;
		}
	}
}
