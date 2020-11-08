using System.Collections.Generic;

namespace Hangman.bootstrap
{
    interface DataLoader
	{
		List<string> loadCountries();
		List<string> loadCapitals();

	}
}
