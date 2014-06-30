using System.Collections.Generic;
using System.Linq;

namespace CSV_Tabellierer
{
    public class Tabellierer
    {
        public IEnumerable<string> Tabelliere(IEnumerable<string> CSV_zeilen)
        {
            var csvLineList = CSV_zeilen.ToList();
            
            //analysieren
            var columnCount = GetColumnCount(csvLineList);
            var rowCount = GetRowCount(csvLineList);
            var splitedContent = Split_CSV_Content(csvLineList, rowCount, columnCount);
            var columnWidth = CalculateColumnWidth(splitedContent, rowCount, columnCount);
            
            //formatieren
            var horizontalRule = GeneratehorizontalRule(columnWidth);
            var formattedOutput = FormatContent(splitedContent, rowCount, columnCount, columnWidth, horizontalRule);
            
            return formattedOutput;
        }

        private IEnumerable<string> FormatContent(string[,] splitedContent, int rowCount, int columnCount, int[] columnWidth, string horizontalRule)
        {
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

        private int GetRowCount(List<string> csvZeilen)
        {
            return csvZeilen.Count;
        }

        private int GetColumnCount(List<string> csvZeilen)
        {
            return csvZeilen[0].Split(';').Length;
        }

        private string[,] Split_CSV_Content(List<string> csvZeilen, int rowCount, int columnCount)
        {
            var retVal = new string[rowCount, columnCount];
            for (int r = 0; r < rowCount; r++)
            {
                var split = csvZeilen[r].Split(';');
                for (int c = 0; c < columnCount; c++)
                {
                    retVal[r, c] = split[c];
                }
            }
            return retVal;
        }

        private int[] CalculateColumnWidth(string[,] content, int rowCount, int columnCount)
        {
            var retVal = new int[columnCount];
            for (int r = 0; r < rowCount; r++)
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
