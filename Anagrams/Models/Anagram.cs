using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anagrams.Models
{
	public interface ILexicon
	{
		IEnumerable<string> GetAnagrams(string input);
	}

	public class LexiconCache : ILexicon
	{
		static readonly LexiconCache instance = new LexiconCache();
		private IDictionary<string, IList<string>> cachedListOfAnagrams;
		private bool IsLoaded { get; set; }

		static LexiconCache()
		{
		}

		LexiconCache()
		{
			cachedListOfAnagrams = new Dictionary<String, IList<string>>();
		}

		public static LexiconCache Instance
		{
			get
			{
				if (!instance.IsLoaded)
				{
					IDictionaryReader dictionary = new DictionaryReader();
					instance.SortIntoBuckets(dictionary.Read());

					// TODO: Create a Dictionary<string, List<string>> that sorts the given words into buckets of anagrams
				}

				return instance;
			}
		}

		private void SortIntoBuckets(IEnumerable<string> listOfWords)
		{
			foreach (string word in listOfWords)
			{
				string sortedWord = new string(word.OrderBy(ch => ch).ToArray());
				AddWord(sortedWord, word);
			}
		}

		private void AddWord(string sortedKey, string word)
		{
			if (!cachedListOfAnagrams.ContainsKey(sortedKey))
			{
				IList<string> anagramList = new List<string>();
				anagramList.Add(word);
				cachedListOfAnagrams.Add(sortedKey, anagramList);
			}
			else
			{
				cachedListOfAnagrams[sortedKey].Add(word);
			}
		}

		public IEnumerable<string> GetAnagrams(string input)
		{
			var sortedInput = new string(input.OrderBy(ch => ch).ToArray());
			// TODO: Consider what happens if I enter a gibberish word here?
			if (!cachedListOfAnagrams.ContainsKey(sortedInput))
			{
				return new List<string>(); // or return null here?
				//IList<string> newWordList = new List<string>();
				//newWordList.Add(input);
				//cachedListOfAnagrams.Add(sortedInput, newWordList);
			}
			return cachedListOfAnagrams[sortedInput].AsEnumerable<string>();
		}
	}
}