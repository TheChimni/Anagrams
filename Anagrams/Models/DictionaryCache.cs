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
		private static DictionaryCache Instance = new DictionaryCache();
		public static IDictionaryReader Reader { get; set; }

		DictionaryCache()
		{
		}

		static DictionaryCache()
		{
		}
		
		public static IDictionaryCache GetInstance()
		{
			if (!Instance.IsLoaded) 
			{ 
				Instance.IsLoaded = true;
				if (Reader != null)
				{
					foreach (var word in Reader.Read())
					{
						// TODO: 
					}
				}
			}
			return Instance;
		}

		public static void Reset()
		{
			Instance = new DictionaryCache();
		}

		public bool IsLoaded { get; private set; }
	}
}