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
		public static IDictionaryCache GetInstance()
		{
			return null;
		}
	}
}