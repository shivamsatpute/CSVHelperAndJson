using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVHelperAndJson
{
    class ReadCSV_And_WriteJSON
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\HP\source\repos\CSVHelperAndJson\Utility\Addresses.csv";
            string exportFilePath = @"C:\Users\HP\source\repos\CSVHelperAndJson\Utility\Export.json";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses csv.");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstname);
                    Console.Write("\t" + addressData.lastname);
                    Console.Write("\t" + addressData.address);
                    Console.Write("\t" + addressData.city);
                    Console.Write("\t" + addressData.state);
                    Console.Write("\t" + addressData.code);

                }
                Console.WriteLine("**********************Reading fromcsv file and Write to csv file in json Format **************************");

                //Writing json file

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }

            }
        }

    }
}
