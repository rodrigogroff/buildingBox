using DataModel;
using System.Net;
using System.Web.Http;

namespace BuildingBox.Web.Controllers
{
	public class RegisterController : ApiController
	{
		public IHttpActionResult Post(User mdl)
		{
			using (var db = new BuildingBoxDB())
			{
				var resp = "";

				if (!mdl.Create(db, ref resp))
					return BadRequest(resp);

				return Ok(mdl);
			}
		}
	}
}
