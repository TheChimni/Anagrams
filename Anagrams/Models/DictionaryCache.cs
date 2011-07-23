using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anagrams.Models
{
	public interface IDictionaryCache
	{
		bool IsLoaded { get; }
	}

	public class DictionaryCache : IDictionaryCache
	{
		private static DictionaryCache	Instance = new DictionaryCache(); 

		DictionaryCache()
		{
		}

		static DictionaryCache()
		{
		}
		
		public static IDictionaryCache GetInstance()
		{
			if (!Instance.IsLoaded) { Instance.IsLoaded = true; }
			return Instance;
		}

		public static void Reset()
		{
			Instance = new DictionaryCache();
		}

		public bool IsLoaded { get; private set; }
	}
}