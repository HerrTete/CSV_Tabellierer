using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSV_Tabellierer;
namespace CSV_Tabellierer_Test
{
    [TestClass]
    public class TabelliererTest
    {
        [TestMethod]
        public void TabelliereTest()
        {
            //Setup
            var testInput = new List<string>{   "Name;Strasse;Ort;Alter",
                                                "Peter Pan;Am Hang 5;12345 Einsam;42",
                                                "Maria Schmitz;Kölner Straße 45;50123 Köln;43",
                                                "Paul Meier;Münchener Weg 1;87654 München;65"};

            var expectedResult = new List<string> {     "Name         |Strasse         |Ort          |Alter|", 
                                                        "-------------+----------------+-------------+-----+", 
                                                        "Peter Pan    |Am Hang 5       |12345 Einsam |42   |", 
                                                        "Maria Schmitz|Kölner Straße 45|50123 Köln   |43   |",
                                                        "Paul Meier   |Münchener Weg 1 |87654 München|65   |"};

            //Test
            var result = new Tabellierer().Tabelliere(testInput).ToList();

            //Prüfung
            Assert.AreEqual(expectedResult.Count, result.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }
    }
}
