using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anagrams.Models;
using Anagrams.Models.ViewModels;

namespace Anagrams.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";
			var model = new IndexViewModel();
			return View(model);
		}

		[HttpPost]
		public ActionResult Index(string word)
		{
			IEnumerable<string> anagrams = DictionaryCache.GetInstance().GetAnagrams(word);
			return View(anagrams);
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
