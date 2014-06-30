using System.Collections.Generic;
using System.Linq;

namespace CSV_Tabellierer
{
    public class Tabellierer
    {
        public IEnumerable<string> Tabelliere(IEnumerable<string> CSV_zeilen)
        {
            var csvLineList = CSV_zeilen.ToList();
            
            var splitedContent = Split_CSV_Content(csvLineList);
            var columnWidth = CalculateColumnWidth(splitedContent);
            var horizontalRule = GeneratehorizontalRule(columnWidth);
            var formattedOutput = FormatContent(splitedContent, columnWidth, horizontalRule);
            
            return formattedOutput;
        }

        private IEnumerable<string> FormatContent(string[,] splitedContent, int[] columnWidth, string horizontalRule)
        {
            var rowCount = splitedContent.GetLength(0);
            var columnCount = splitedContent.GetLength(1);
            var retVal = new List<string>();
            for (int r = 0; r < rowCount; r++)
            {
                var line = string.Empty;
                for (int c = 0; c < columnCount; c++)
                {
                    line += splitedContent[r, c].PadRight(columnWidth[c]);
                    line += "|";
                }
                retVal.Add(line);
                if (r == 0)
                {
                    retVal.Add(horizontalRule);
                }
            }
            return retVal;
        }

        private string GeneratehorizontalRule(int[] columnWidth)
        {
            var hr = string.Empty;
            foreach (var i in columnWidth)
            {
                hr += string.Empty.PadRight(i, '-');
                hr += "+";
            }
            return hr;
        }

        private string[,] Split_CSV_Content(List<string> csvZeilen)
        {
            var columnCount = csvZeilen[0].Split(';').Length;
            var retVal = new string[csvZeilen.Count, columnCount];
            for (int r = 0; r < csvZeilen.Count; r++)
            {
                var split = csvZeilen[r].Split(';');
                for (int c = 0; c < columnCount; c++)
                {
                    retVal[r, c] = split[c];
                }
            }
            return retVal;
        }

        private int[] CalculateColumnWidth(string[,] content)
        {
            var columnCount = content.GetLength(1);
            var retVal = new int[columnCount];
            for (int r = 0; r < content.GetLength(0); r++)
            {
                for (int c = 0; c < columnCount; c++)
                {
                    var width = content[r, c].Length;
                    if (retVal[c] < width)
                    {
                        retVal[c] = width;
                    }
                }
            }
            return retVal;
        }
    }
}
