using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class UserMeetingFilter
	{
		public int skip, take;
		public string busca;
		public long? fkUser;
	}

	public partial class UserMeeting
	{
		public List<UserMeeting> ComposedFilters(BuildingBoxDB db, ref int count, UserMeetingFilter filter)
		{
			var user = db.GetCurrentUser();

			if (user.fkClientType == UserType.Client)
				filter.fkUser = user.id;

			var query = from e in db.UserMeetings select e;

			if (filter.busca != null)
				query = from e in query
						where	e.stMeetingDetails.ToUpper().Contains(filter.busca) ||
								e.stMeetingMotivation.ToUpper().Contains(filter.busca)
						select e;

			count = query.Count();

			query = query.OrderByDescending(y => y.nuYear).
				OrderByDescending(y => y.fkMonth).
				OrderByDescending(y => y.nuDay).
				OrderByDescending(y => y.nuHour).
				OrderByDescending(y => y.nuMinute);

			var results = (query.Skip(() => filter.skip).Take(() => filter.take)).ToList();

			results.ForEach(y => { y = y.LoadAssociations(db); });

			return results;
		}
	}
}
