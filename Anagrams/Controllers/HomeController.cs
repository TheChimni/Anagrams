﻿using System;
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
		public ActionResult Index(IndexViewModel model)
		{
			model.Anagrams = DictionaryCache.GetInstance().GetAnagrams(model.Word);
			return View(model);
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
