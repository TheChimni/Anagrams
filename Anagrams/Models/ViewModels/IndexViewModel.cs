using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anagrams.Models.ViewModels
{
	public class IndexViewModel
	{
		public IndexViewModel()
		{
			Word = String.Empty;
			Anagrams = new List<string>() { };
		}
		public string Word { get; set; }
		public IEnumerable<string> Anagrams { get; set; }
		public ExceptionViewModel Exception { get; set; }
	}
}