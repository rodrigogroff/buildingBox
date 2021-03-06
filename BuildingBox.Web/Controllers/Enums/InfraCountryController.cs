﻿using System.Linq;
using System.Net;
using System.Web.Http;
using DataModel;

namespace BuildingBox.Web.Controllers
{
	public class InfraCountryController : ApiController
	{
		EnumInfraCountry _enum = new EnumInfraCountry();

		public IHttpActionResult Get()
		{
			string busca = Request.GetQueryStringValue("busca")?.ToUpper();
			var fkContinent = Request.GetQueryStringValue<long?>("fkContinent", null);

			var query = (from e in _enum.lst select e);

			if (busca != null)
				query = from e in query where e.stName.ToUpper().Contains(busca) select e;

			if (fkContinent != null)
				query = from e in query where e.fkContinent == fkContinent select e;

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
