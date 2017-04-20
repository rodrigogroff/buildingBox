using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class UserCustomizationFilter
	{
		public int skip, take;
		public string busca;
	}

	public partial class UserCustomization
	{
		public List<UserCustomization> ComposedFilters(BuildingBoxDB db, ref int count, UserCustomizationFilter filter)
		{
			var query = from e in db.UserCustomizations select e;

			if (filter.busca != null)
				query = from e in query
						where e.stProtocol.Contains(filter.busca)
						select e;

			count = query.Count();

			query = query.OrderByDescending(y => y.id);

			var results = (query.Skip(() => filter.skip).Take(() => filter.take)).ToList();

			results.ForEach(y => { y = y.LoadAssociations(db); });

			return results;
		}
	}
}
