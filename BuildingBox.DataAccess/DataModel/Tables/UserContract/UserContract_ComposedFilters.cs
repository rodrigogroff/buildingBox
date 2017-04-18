using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class UserContractFilter
	{
		public int skip, take;
		public string busca;
	}

	public partial class UserContract
	{
		public List<UserContract> ComposedFilters(BuildingBoxDB db, ref int count, UserContractFilter filter)
		{
			var query = from e in db.UserContracts select e;

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
