using System.Linq;
using System.Net;
using System.Web.Http;
using DataModel;

namespace BuildingBox.Web.Controllers
{
	public class InfraCityController : ApiController
	{
		EnumInfraCity _enum = new EnumInfraCity();

		public IHttpActionResult Get()
		{
			string busca = Request.GetQueryStringValue("busca")?.ToUpper();
			var fkCountry = Request.GetQueryStringValue<long?>("fkCountry", null);

			var query = (from e in _enum.lst select e);

			if (busca != null)
				query = from e in query where e.stName.ToUpper().Contains(busca) select e;

			if (fkCountry != null)
				query = from e in query where e.fkCountry == fkCountry select e;

			return Ok(new
			{
				count = query.Count(),
				results = query.ToList()
			});
		}

		public IHttpActionResult Get(long id)
		{
			var model = _enum.Get(id);

			if (model != null)
				return Ok(model);

			return StatusCode(HttpStatusCode.NotFound);
		}
	}
}
