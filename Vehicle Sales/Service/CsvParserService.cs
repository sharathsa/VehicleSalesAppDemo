using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Vehicle_Sales.Models;

namespace Vehicle_Sales
{
    public class CsvParserService : ICsvParserService
    {
        public async Task<T> ProcessCsv<T>(Stream stream, Func<List<string>, T> transformation)
        {
            string line = string.Empty;

            var fileContent = new List<string>();
            using (var fileReader = new StreamReader(stream, Encoding.Default))
            {
                while ((line = await fileReader.ReadLineAsync()) != null)
                {
                    fileContent.Add(line);
                }
            }

            return transformation(fileContent);
        }
    }
}