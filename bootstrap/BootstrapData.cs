using System;
using System.Collections.Generic;

namespace Hangman.bootstrap
{
    class BootstrapData
	{
        List<string> euCountries = new List<string>();
        List<string> euCapitals = new List<string>();

        public List<string> loadCountries()
        {
            euCountries.Add("Albania");
            euCountries.Add("Andorra");
            euCountries.Add("Austria");
            euCountries.Add("Belarus");
            euCountries.Add("Belgium");
            euCountries.Add("Bosnia and Herzegovina");
            euCountries.Add("Bulgaria");
            euCountries.Add("Croatia");
            euCountries.Add("Czech Republic");
            euCountries.Add("Denmark");
            euCountries.Add("Estonia");
            euCountries.Add("Finland");
            euCountries.Add("France");
            euCountries.Add("Germany");
            euCountries.Add("Greece");
            euCountries.Add("Hungary");
            euCountries.Add("Iceland");
            euCountries.Add("Ireland");
            euCountries.Add("Italy");
            euCountries.Add("Kosovo");
            euCountries.Add("Latvia");
            euCountries.Add("Liechtenstein");
            euCountries.Add("Lithuania");
            euCountries.Add("Luxembourg");
            euCountries.Add("North Macedonia");
            euCountries.Add("Latvia");
            euCountries.Add("Malta");
            euCountries.Add("Moldova");
            euCountries.Add("Monaco");
            euCountries.Add("Montenegro");
            euCountries.Add("Netherlands ");
            euCountries.Add("Norway");
            euCountries.Add("Poland");
            euCountries.Add("Portugal");
            euCountries.Add("Romania");
            euCountries.Add("Russia");
            euCountries.Add("San Marino");
            euCountries.Add("Serbia");
            euCountries.Add("Slovakia");
            euCountries.Add("Slovenia");
            euCountries.Add("Sweden");
            euCountries.Add("Switzerland");
            euCountries.Add("Turkey");
            euCountries.Add("Ukraine");
            euCountries.Add("United Kingdom");
            euCountries.Add("Vatican City");
            return euCountries;
        }

        public List<String> loadCapitals()
        {
            euCapitals.Add("Tirana");
            euCapitals.Add("Andorra");
            euCapitals.Add("Vienna");
            euCapitals.Add("Minsk");
            euCapitals.Add("Brussels");
            euCapitals.Add("Sarajevo");
            euCapitals.Add("Sofia");
            euCapitals.Add("Zagreb");
            euCapitals.Add("Prague");
            euCapitals.Add("Copenhagen");
            euCapitals.Add("Tallinn");
            euCapitals.Add("Helsinki");
            euCapitals.Add("Paris");
            euCapitals.Add("Berlin");
            euCapitals.Add("Athens");
            euCapitals.Add("Budapest");
            euCapitals.Add("Reyjavík");
            euCapitals.Add("Dublin");
            euCapitals.Add("Rome");
            euCapitals.Add("Pristina");
            euCapitals.Add("Riga");
            euCapitals.Add("Vaduz");
            euCapitals.Add("Vilnius");
            euCapitals.Add("Luxembourg");
            euCapitals.Add("Riga");
            euCapitals.Add("Skopje");
            euCapitals.Add("Valletta");
            euCapitals.Add("Chisinau");
            euCapitals.Add("Monaco");
            euCapitals.Add("Podgorica");
            euCapitals.Add("Amsterdam");
            euCapitals.Add("Oslo");
            euCapitals.Add("Warsaw");
            euCapitals.Add("Lisbon");
            euCapitals.Add("Bucharest");
            euCapitals.Add("Moscow");
            euCapitals.Add("San Marino");
            euCapitals.Add("Belgrade");
            euCapitals.Add("Bratislava");
            euCapitals.Add("Ljubljana");
            euCapitals.Add("Stockholm");
            euCapitals.Add("Bern");
            euCapitals.Add("Ankara");
            euCapitals.Add("Kiev");
            euCapitals.Add("London");
            euCapitals.Add("Vatican");
            toLowerCase(euCapitals);
            return euCapitals;
        }

        private void toLowerCase(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].ToLower();
            }
        }
    }
}
