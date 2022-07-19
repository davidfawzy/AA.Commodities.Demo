using AA.CommoditiesDashboard.WebAPI.Data.Models;
using AA.CommoditiesDashboard.WebAPI.Mappings.CsvHelper;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AA.CommoditiesDashboard.WebAPI.Extensions
{
    public class FileExtension
    {
        public static List<ModelResults> GetCSVData(string filepath)
        {
            if (string.IsNullOrEmpty(filepath)) throw new ArgumentNullException($"filePath is null");
            using TextReader reader = new StreamReader(filepath, Encoding.Default);
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            csvReader.Context.RegisterClassMap<ModelResultsMap>();
            var result = csvReader.GetRecords<ModelResults>();
            return result.ToList();
        }
    }
}
