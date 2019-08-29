using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Vehicle_Sales
{
    public interface ICsvParserService
    {
        Task<T> ProcessCsv<T>(Stream stream, Func<List<string>, T> transformation);
    }
}