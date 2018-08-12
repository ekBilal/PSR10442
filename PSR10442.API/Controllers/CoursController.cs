using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;

using PSR10442.API.Models;
using PSR10442.Models;

namespace PSR10442.API.Controllers
{
	public class CoursController : ApiController
	{

		private Dal dal = new Dal();

		// GET: api/Cours
		public string Get()
		{
			var cours = dal.GetCours();
			return JsonConvert.SerializeObject(cours);
		}

		// GET: api/Cours/5
		[ResponseType(typeof(Cours))]
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var cours = dal.GetCours(id);
			return Ok(cours);
		}

		// POST: api/Cours
		[HttpPost]
		public IHttpActionResult Post([FromBody] string nom)
		{
			if (string.IsNullOrWhiteSpace(nom)) { }
//				return BadRequest();
			var newCours = dal.AddCours("Anglais");
			return Ok(newCours);
		}

		// PUT: api/Cours/5
		public void Put(int id, [FromBody]string value)
        {
			throw new NotImplementedException();
        }

        // DELETE: api/Cours/5
        public IHttpActionResult Delete(int id)
        {
			dal.DeleteCours(id);
			return Ok();
        }
    }
}
