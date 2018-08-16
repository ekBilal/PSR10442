using PSR10442.API.Models;
using PSR10442.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PSR10442.API.Controllers
{
    [System.Web.Http.Authorize]
    public class InscriptionController : ApiController
    {
		private Dal dal = new Dal();

		// GET: api/Inscription
		[ResponseType(typeof(IList<Inscrit>))]
		public IHttpActionResult Get()
        {
			int idCours;
			if (!int.TryParse(Request.Headers.GetValues("idCours").FirstOrDefault(), out idCours)){
				return BadRequest();
			}
			var etudiants = dal.GetEtudiantInscrit(idCours);
			return Ok(etudiants);
        }

        // GET: api/Inscription/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Inscription
        public IHttpActionResult Post()
        {
			if (!Request.Headers.Contains("idEtudiant")) return BadRequest();
			if (!Request.Headers.Contains("idCours")) return BadRequest();

			try
			{
				int idEtudiant = int.Parse(Request.Headers.GetValues("idEtudiant").FirstOrDefault());
				int idCours = int.Parse(Request.Headers.GetValues("idCours").FirstOrDefault());
				dal.Inscrire(idEtudiant, idCours);
			}
			catch (Exception)
			{
				return BadRequest();
			}


			return Ok();
		}

        // PUT: api/Inscription/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inscription/5
        public void Delete(int id)
        {
        }
    }
}
