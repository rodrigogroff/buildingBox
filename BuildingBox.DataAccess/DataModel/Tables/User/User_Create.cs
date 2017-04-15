using LinqToDB;
using System;
using System.Linq;

namespace DataModel
{
	public partial class User
	{
		bool CheckDuplicate(User item, BuildingBoxDB db)
		{
			var query = from e in db.Users select e;

			if (item.stContactEmail != null)
			{
				query = from e in query where e.stContactEmail.ToUpper().Contains(item.stContactEmail.ToUpper()) select e;
			}
				
			if (item.id > 0)
				query = from e in query where e.id != item.id select e;

			return query.Any();
		}

		public bool Create(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			if (CheckDuplicate(this, db))
			{
				resp = "Login already taken";
				return false;
			}
			
			id = Convert.ToInt64(db.InsertWithIdentity(this));

			return true;
		}
	}
}
