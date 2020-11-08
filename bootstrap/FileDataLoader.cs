using System.Collections.Generic;
using System.IO;

namespace Hangman.bootstrap
{
    class FileDataLoader
	{
		private readonly List<string> listOfCountries = new List<string>();
		private readonly List<string> listOfCapitals = new List<string>();
		private readonly string filePath = @"..\..\countries_and_capitals.txt.txt";

		public void readFile()
		{

			var lines = File.ReadAllLines(filePath);

			for (int i = 0; i < lines.Length; i++)
			{
				var fields = lines[i].Split('|');
				listOfCountries.Add(fields[0].Trim());
				listOfCapitals.Add(fields[1].ToLower().Trim());
				//Console.WriteLine("Country: " + fields[0].Trim() + " Capital: " + fields[1].Trim());
			}
		}

		public List<string> loadCapitals()
		{
			return listOfCapitals;
		}

		public List<string> loadCountries()
		{
			return listOfCountries;
		}
	}
}
