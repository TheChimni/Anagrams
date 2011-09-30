using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anagrams.Models.ViewModels
{
	public class ExceptionViewModel
	{
		public string Message { get; set; }
		public string CallStack { get; set;}
	}
}