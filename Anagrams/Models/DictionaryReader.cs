using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Anagrams.Models
{
	public interface IDictionaryReader
	{
		IEnumerable<string> Read();
	}

	public class DictionaryReader : IDictionaryReader
	{
		private const string FILE_NAME = @"..\Content\wordlist.txt";

		public DictionaryReader()
		{
		}

		public IEnumerable<string> Read()
		{
			if (!File.Exists(FILE_NAME))
			{
				throw new Exception(string.Format("{0} does not exist!", FILE_NAME));
			}

			// Read words from the file
			using (StreamReader reader = File.OpenText(FILE_NAME))
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