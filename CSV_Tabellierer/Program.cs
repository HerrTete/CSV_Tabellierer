using System;
using System.Collections.Generic;
using System.Linq;

namespace CSV_Tabellierer
{
    class Program
    {
        static void Main(string[] args)
        {

            var testInput = new List<string>{   "Name;Strasse;Ort;Alter",
                                                "Peter Pan;Am Hang 5;12345 Einsam;42",
                                                "Maria Schmitz;Kölner Straße 45;50123 Köln;43",
                                                "Paul Meier;Münchener Weg 1;87654 München;65"};

            var result = new Tabellierer().Tabelliere(testInput).ToList();

            PrintOutput(result);
        }

        private static void PrintOutput(List<string> result)
        {
            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
    
}
