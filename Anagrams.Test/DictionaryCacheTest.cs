using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Anagrams.Models;

namespace Anagrams.Test
{
	[TestFixture]
	public class DictionaryCacheTest
	{
		[Test]
		public void GetCache()
		{
			IDictionaryCache cache = DictionaryCache.GetInstance();
			Assert.IsNotNull(cache);
		}
	}
}
