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
		// TODO: Don't cache the list of words here, ReadFile should read directly from the file and yield directly to the client
		//private IList<string> dictionaryWords;

		public DictionaryReader()
		{
		}

		public IEnumerable<string> Read()
		{
			if (!File.Exists(FILE_NAME))
			{
				throw new Exception(string.Format("{0} does not exist!", FILE_NAME));
			}

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