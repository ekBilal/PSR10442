using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PSR10442.Models;

namespace PSR10442.Web.Controllers
{
    [Authorize]
    public class CoursController : Controller
    {
		HttpClient client = new HttpClient();
		readonly Uri adress = new Uri("http://localhost:50823/api/");

		// GET: Cours
		public async Task<ActionResult> Index()
        {
			var token = await UserProfileController.GetTokenForApi();
			client.BaseAddress = adress;
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var result = await client.GetStringAsync("cours");
			var cours = JsonConvert.DeserializeObject<List<Cours>>(result);
			return View(cours);
		}

        // GET: Cours/Details/5
        public ActionResult Details(int id)
        {
			client.BaseAddress = adress;
			var result = client.GetStringAsync("cours/"+id).Result;
			var cours = JsonConvert.DeserializeObject<Cours>(result);
			return View(cours);
		}

        // GET: Cours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cours/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
				client.BaseAddress = adress;
				var nom = collection.GetValues("Nom").FirstOrDefault();
				client.DefaultRequestHeaders.Add("nom", nom);
				var rep = client.PostAsync("Cours",null);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cours/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
				client.BaseAddress = adress;
				var nom = collection.GetValues("Nom").FirstOrDefault();
				var actif = bool.Parse(collection.GetValues("Actif").FirstOrDefault());
				var cours = new Cours { IdCours = id, Nom = nom, Actif = actif };
				var json = JsonConvert.SerializeObject(cours);

				using (HttpContent httpContent = new StringContent(json))
				{
					httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
					var rep = client.PutAsync("Cours", httpContent).Result;
				}
				return RedirectToAction("Index");


			}
			catch
            {
                return View();
            }
        }

        // GET: Cours/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cours/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				var res = client.DeleteAsync("cours/" + id).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
