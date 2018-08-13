using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using PSR10442.API.Models;
using PSR10442.Models;

namespace PSR10442.API.Controllers
{
	public class CoursController : ApiController
	{

		private Dal dal = new Dal();

		// GET: api/Cours
		[ResponseType(typeof(List<Cours>))]
		public IHttpActionResult Get()
		{
			var cours = dal.GetCours();
			return Ok(cours);
		}

		// GET: api/Cours/5
		[ResponseType(typeof(Cours))]
		public IHttpActionResult Get(int id)
		{
			var cours = dal.GetCours(id);
			return Ok(cours);
		}

		// POST: api/Cours
		[HttpPost]
		[ResponseType(typeof(Cours))]
		public IHttpActionResult Post()
		{
			var nom = Request.Headers.GetValues("nom").FirstOrDefault();
			if (string.IsNullOrWhiteSpace(nom)) return BadRequest();
			var newCours = dal.AddCours(nom);
			return Ok(newCours);
		}

		// PUT: api/Cours/5
		[ResponseType(typeof(Cours))]
		public IHttpActionResult Put([FromBody]Cours cours)
        {
			if (!ModelState.IsValid) return BadRequest();
			try
			{
				var newCours = dal.SetCours(cours);
				return Ok(newCours);
			}
			catch (ObjectNotFoundException)
			{
				return NotFound();
			}

		}

        // DELETE: api/Cours/5
        public IHttpActionResult Delete(int id)
        {
			try
			{
				dal.DeleteCours(id);
				return Ok();
			}
			catch (ObjectNotFoundException)
			{
				return BadRequest();
			}
		}
	}
}
