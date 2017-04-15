using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class UserFilter
	{
		public int skip, take;
		public string busca;
	}

	public partial class User
	{
		public List<User> ComposedFilters(BuildingBoxDB db, ref int count, UserFilter filter)
		{
			var query = from e in db.Users select e;

			if (filter.busca != null)
				query = from e in query
						where e.stClientName.ToUpper().Contains(filter.busca) || e.stContactEmail.ToUpper().Contains(filter.busca) 
						select e;

			count = query.Count();

			query = query.OrderBy(y => y.stClientName);

			var results = (query.Skip(() => filter.skip).Take(() => filter.take)).ToList();

			results.ForEach(y => { y = y.LoadAssociations(db); });

			return results;
		}
	}
}
