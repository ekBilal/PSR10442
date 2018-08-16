using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;
using PSR10442.Models;

namespace PSR10442.Web.Controllers
{
	[System.Web.Mvc.Authorize]
	public class HomeController : Controller
	{
		HttpClient client = new HttpClient();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}