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
		[SetUp]
		public void Setup()
		{
			DictionaryCache.Reset();
		}

		[Test]
		public void GetCache()
		{
			IDictionaryCache cache = DictionaryCache.GetInstance();
			Assert.IsNotNull(cache);
		}

		[Test]
		public void CacheShouldBeSingleton()
		{
			IDictionaryCache cache1 = DictionaryCache.GetInstance();
			IDictionaryCache cache2 = DictionaryCache.GetInstance();
			Assert.AreSame(cache1, cache2);
		}

		[Test]
		public void CacheCanBeReset()
		{
			IDictionaryCache cache1 = DictionaryCache.GetInstance();
			DictionaryCache.Reset();
			IDictionaryCache cache2 = DictionaryCache.GetInstance();
			Assert.AreNotSame(cache1, cache2);
		}

		[Test]
		public void CacheShouldBeLoaded()
		{
			IDictionaryCache cache = DictionaryCache.GetInstance();
			Assert.IsTrue(cache.IsLoaded);
		}

		[Test]
		public void ShouldBeAbleToOverrideReader()
		{
			var reader = new MockReader();
			DictionaryCache.Reader = reader;
			DictionaryCache.GetInstance();
			Assert.AreEqual(1, reader.CallCount);
		}

		[Test]
		public void SimpleAnagramLookup()
		{
			var reader = new MockReader { Strings = new string[] { "silent", "listen" } };
			DictionaryCache.Reader = reader;
			IEnumerable<string> anagrams =  DictionaryCache.GetInstance().GetAnagrams("enlist");
			Assert.AreEqual(anagrams.Count(), 2);
			Assert.IsTrue(anagrams.Contains("silent"));
			Assert.IsTrue(anagrams.Contains("listen"));
		}
	}

	class MockReader : IDictionaryReader
	{
		public int CallCount { get; private set; }
		public string[] Strings { get; set; }

		public IEnumerable<string> Read()
		{
			CallCount++;
			return Strings ?? new string[0];
		}
	}
}
