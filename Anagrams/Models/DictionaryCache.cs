using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anagrams.Models
{
	public interface IDictionaryCache
	{
		bool IsLoaded { get; }
		IEnumerable<string> GetAnagrams(string input);
	}

	public class DictionaryCache : IDictionaryCache
	{
		private static DictionaryCache Instance = new DictionaryCache();
		public static IDictionaryReader Reader { get; set; }
		public IDictionary<string, IList<string>> AnagramCache { get; private set; }

		DictionaryCache()
		{
			AnagramCache = new Dictionary<string, IList<string>>();
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
						string sortedWord = new string(word.OrderBy(ch => ch).ToArray());
						if (!Instance.AnagramCache.ContainsKey(sortedWord))
						{
							IList<string> anagrams = new List<string>();
							anagrams.Add(word);
							Instance.AnagramCache.Add(sortedWord, anagrams);
						}
						else
						{
							Instance.AnagramCache[sortedWord].Add(word);
						}
					}
				}
			}
			return Instance;
		}

		public IEnumerable<string> GetAnagrams(string input)
		{
			var sortedInput = new string(input.OrderBy(ch => ch).ToArray());
			return AnagramCache.ContainsKey(sortedInput) ? AnagramCache[sortedInput].AsEnumerable() :
				new List<string>();
		}

		public static void Reset()
		{
			Instance = new DictionaryCache();
		}

		public bool IsLoaded { get; private set; }
	}
}