using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Http.Description;

using Newtonsoft.Json;

using PSR10442.API.Models;
using PSR10442.Models;

namespace PSR10442.API.Controllers
{
	public class EtudiantsController : ApiController
	{
		private Dal dal = new Dal();

		// GET: api/Etudiants
		[ResponseType(typeof(IList<Etudiant>))]
		public IHttpActionResult Get()
		{
			var etudiants = dal.GetEtudiants();
			var json = JsonConvert.SerializeObject(etudiants);
			return Ok(json);
		}

		// GET: api/Etudiants/5
		[ResponseType(typeof(Etudiant))]
		public IHttpActionResult GetEtudiant(int id)
		{
			Etudiant etudiant = dal.GetEtudiant(id);
			if (etudiant == null) { return NotFound(); }
			return Ok(etudiant);
		}

		// PUT: api/Etudiants/5
		[ResponseType(typeof(Etudiant))]
		public IHttpActionResult Put(int id, Etudiant etudiant)
		{
			try
			{
				var newEtudiant = dal.SetEtudiant(id, etudiant.estInscrit);
				return Ok(newEtudiant);
			}
			catch (ObjectNotFoundException)
			{
				return NotFound();
			}
		}

		// POST: api/Etudiants
		[ResponseType(typeof(Etudiant))]
		public IHttpActionResult Post(Etudiant etudiant)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var newEtudiant = dal.AddEtudiant(etudiant);

			return Ok(newEtudiant);
		}

		// DELETE: api/Etudiants/5
		[ResponseType(typeof(Etudiant))]
		public IHttpActionResult Delete(int id)
		{
			try
			{
				if (!dal.DeleteEtudiant(id))
					return BadRequest();
			}
			catch (ObjectNotFoundException)
			{
				return NotFound();
			}

			return Ok();
		}


	}

}