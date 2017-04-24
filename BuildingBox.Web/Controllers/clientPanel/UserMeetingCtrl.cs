using DataModel;
using System.Net;
using System.Web.Http;

namespace BuildingBox.Web.Controllers
{
	public class UserMeetingController : ApiControllerBase
	{
		public IHttpActionResult Get()
		{
			using (var db = new BuildingBoxDB())
			{
				var count = 0; var mdl = new UserMeeting();

				var results = mdl.ComposedFilters(db, ref count, new UserMeetingFilter()
				{
					skip = Request.GetQueryStringValue("skip", 0),
					take = Request.GetQueryStringValue("take", 15),
					busca = Request.GetQueryStringValue("busca")?.ToUpper()					
				});

				return Ok(new { count = count, results = results });
			}
		}

		public IHttpActionResult Get(long id)
		{
			using (var db = new BuildingBoxDB())
			{
				var model = db.UserMeeting(id);

				if (model != null)
					return Ok(model.LoadAssociations(db));

				return StatusCode(HttpStatusCode.NotFound);
			}
		}

		public IHttpActionResult Post(UserMeeting mdl)
		{
			using (var db = new BuildingBoxDB())
			{
				var resp = "";

				if (!mdl.Create(db, ref resp))
					return BadRequest(resp);

				return Ok(mdl);
			}
		}

		public IHttpActionResult Put(long id, UserMeeting mdl)
		{
			using (var db = new BuildingBoxDB())
			{
				var resp = "";

				if (!mdl.Update(db, ref resp))
					return BadRequest(resp);

				return Ok(mdl);
			}
		}
	}
}
