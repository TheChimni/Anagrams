using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anagrams.Models;

namespace Anagrams.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";
			//IDictionaryCache cache = DictionaryCache.GetInstance().GetAnagrams();
			return View("");
		}

		//[HttpPost]
		//public ActionResult Index(string word)
		//{
		//    IDictionaryCache cache = DictionaryCache.GetInstance().GetAnagrams(word);
		//    return View();
		//}

		public ActionResult About()
		{
			return View();
		}
	}
}
