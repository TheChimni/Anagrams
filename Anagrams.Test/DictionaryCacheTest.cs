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
	}

	class MockReader : IDictionaryReader
	{
		public int CallCount { get; set; }

		public IEnumerable<string> Read()
		{
			CallCount++;
			return new string[0];
		}
	}
}
