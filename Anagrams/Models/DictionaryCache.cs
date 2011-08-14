using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anagrams.Models
{
	public interface IDictionaryCache
	{
		// This property could well be removed
		bool IsLoaded { get; }

		/// <summary>
		/// Looks up input string into the Anagram Cache to returns all anagrams for the input string
		/// </summary>
		/// <param name="input"></param>
		/// <returns>An IEnumerable of strings</returns>
		IEnumerable<string> GetAnagrams(string input);
	}

	public class DictionaryCache : IDictionaryCache
	{
		// Instance of the singleton class
		private static DictionaryCache Instance = new DictionaryCache();

		static readonly object lockObject = new object();

		// A property that can be set by the test client to enable mocking of dependencies
		public static IDictionaryReader Reader { get; set; }

		// A data structure to cache strings read from a file
		private IDictionary<string, IList<string>> anagramCache;
		
		// Private constructor
		DictionaryCache()
		{
			anagramCache = new Dictionary<string, IList<string>>();
		}

		static DictionaryCache()
		{
		}
		
		public static IDictionaryCache GetInstance()
		{
			lock (lockObject)
			{
				// Check to ensure the cache gets loaded only once into the memory
				if (!Instance.IsLoaded)
				{
					Instance.IsLoaded = true;
					if (Reader != null)
					{
						// Iterate through the list of words read from the an external resource. Could be from a file/database
						foreach (var word in Reader.Read())
						{
							// Sort the word in ascending order
							string sortedWord = new string(word.OrderBy(ch => ch).ToArray());
							if (!Instance.anagramCache.ContainsKey(sortedWord))
							{
								IList<string> anagrams = new List<string>();
								anagrams.Add(word);
								Instance.anagramCache.Add(sortedWord, anagrams);
							}
							else
							{
								Instance.anagramCache[sortedWord].Add(word);
							}
						}
					}
				}
			}
			return Instance;
		}

		public IEnumerable<string> GetAnagrams(string input)
		{
			var sortedInput = new string(input.OrderBy(ch => ch).ToArray());
			return anagramCache.ContainsKey(sortedInput) ? anagramCache[sortedInput].AsEnumerable() :
				new List<string>();
		}

		/// <summary>
		/// Allows the client to refresh the cache
		/// </summary>
		public static void Reset()
		{
			Instance = new DictionaryCache();
		}

		// To ensure the cache gets loaded only the first time an instance is created
		public bool IsLoaded { get; private set; }
	}
}