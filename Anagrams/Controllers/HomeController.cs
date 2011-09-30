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
			return View(new IndexViewModel());
		}

		[HttpPost]
		public ActionResult Index(IndexViewModel model)
		{
			model.Anagrams = DictionaryCache.GetInstance().GetAnagrams(model.Word);

			//if (Request.Headers["accept"] == "application/json")
			if (Request.IsAjaxRequest())
			{
				return Json(model.Anagrams);
			}
			return View(model);
		}

		// For experiment purpose only
		//public ActionResult Json(IndexViewModel model)
		//{
		//    model.Anagrams = DictionaryCache.GetInstance().GetAnagrams(model.Word);
		//    return Json(model.Anagrams, JsonRequestBehavior.AllowGet);
		//}

		public ActionResult About()
		{
			return View();
		}
	}
}
