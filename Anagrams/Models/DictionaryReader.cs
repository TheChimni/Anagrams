using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Anagrams.Models
{
	public interface IDictionaryReader
	{
		IEnumerable<string> Read(string path = null);
	}

	public class DictionaryReader : IDictionaryReader
	{
		private const string FILE_NAME = @"..\Content\wordlist.txt";

		public DictionaryReader()
		{
		}

		public IEnumerable<string> Read(string path)
		{
			var filePath = path ?? FILE_NAME;
			if (!File.Exists(filePath))
			{
				throw new Exception(string.Format("{0} does not exist!", filePath));
			}

			// Read words from the file
			using (StreamReader reader = File.OpenText(filePath))
			{
				string readString = null;
				while ((readString = reader.ReadLine()) != null)
				{
					yield return readString;
				}

				Console.WriteLine("End of file");
			}
		}
	}
}