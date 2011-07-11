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

		static LexiconCache()
		{

		}

		LexiconCache()
		{

		}

		public static LexiconCache Instance
		{
			get
			{
				return instance;
			}
		}

		public IEnumerable<string>  GetAnagrams(string input)
		{
 			throw new NotImplementedException();
		}
	}
}