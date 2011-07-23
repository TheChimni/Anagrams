using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anagrams.Models
{
	public interface IDictionaryCache
	{
	}

	public class DictionaryCache : IDictionaryCache
	{
		private static readonly DictionaryCache	Instance = new DictionaryCache(); 

		DictionaryCache()
		{
		}

		static DictionaryCache()
		{
		}
		
		public static IDictionaryCache GetInstance()
		{
			return Instance;
		}
	}
}