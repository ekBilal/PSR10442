﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSR10442.API;
using PSR10442.API.Controllers;

namespace PSR10442.API.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Disposer
			HomeController controller = new HomeController();

			// Agir
			ViewResult result = controller.Index() as ViewResult;

			// Affirmer
			Assert.IsNotNull(result);
			Assert.AreEqual("Home Page", result.ViewBag.Title);
		}
	}
}
