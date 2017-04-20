using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class TicketFilter
	{
		public int skip, take;
		public string busca;
		public long? fkState, fkUser;
	}

	public partial class Ticket
	{
		public List<Ticket> ComposedFilters(BuildingBoxDB db, ref int count, TicketFilter filter)
		{
			var user = db.GetCurrentUser();

			if (user.fkClientType == UserType.Client)
				filter.fkUser = user.id;

			var query = from e in db.Tickets select e;

			if (filter.busca != null)
				query = from e in query
						where e.stTitle.ToUpper().Contains(filter.busca) ||
							  e.stProtocol.Contains(filter.busca) ||
							  e.stDescription.ToUpper().Contains(filter.busca) 
						select e;

			if (filter.fkUser != null)
				query = from e in query
						where e.fkUserOpen == filter.fkUser
						select e;

			if (filter.fkState != null)
				query = from e in query
						where e.fkTicketState == filter.fkState
						select e;

			count = query.Count();

			query = query.OrderByDescending(y => y.id);

			var results = (query.Skip(() => filter.skip).Take(() => filter.take)).ToList();

			results.ForEach(y => { y = y.LoadAssociations(db); });

			return results;
		}
	}
}
