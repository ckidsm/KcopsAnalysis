using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace KcopsAnalysis
{
    internal class VideoAnalysisResults
    {
        [DisplayName("영상프레임 번호")]
        public int FrameNumber { get; set; }
        [DisplayName("충격수치")]
        public double CrashValue { get; set; }

        //https://www.csharptutorial.net/csharp-file/csharp-read-csv-file/
        public List<Collation> SetCsvFilePacer(string filename)
        {
            using (StreamReader SrtReader = new StreamReader(filename))
            { 
               
                using (CsvReader csvRead = new CsvReader((IParser)SrtReader))
                {
                  return (List<Collation>)csvRead.GetRecords<VideoAnalysisResults>();
                }
               
            }
            
        }
        //Read csv file and return it as a list
        
        public DataTable GetCsvDataTable(string csvFilePath)
        {
            // Create a DataTable
            DataTable dataTable = new DataTable("CsvDataTable");

            // Define column names and properties using a loop
            string[] columnNames = { "FrameNumber", "CrashValue", "Time" };
            Type[] columnDataTypes = { typeof(int), typeof(double), typeof(DateTime) };

            for (int i = 0; i < columnNames.Length; i++)
            {
                // Create DataColumn with specified name and data type
                DataColumn column = new DataColumn(columnNames[i], columnDataTypes[i]);

                // Add the column to the DataTable
                dataTable.Columns.Add(column);
            }



            if (File.Exists(csvFilePath))
            {
                // Read the CSV file into a DataTable
                 dataTable = ReadCsvFile(csvFilePath);

                // You can now work with the DataTable
                // For example, you can iterate through rows and columns
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        Console.Write(item + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The CSV file does not exist.");
            }



            return dataTable;
        }

        static DataTable ReadCsvFile(string filePath)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read the header row
                    string headerRow = reader.ReadLine();

                    // Check if the header row is null or empty
                    if (!string.IsNullOrWhiteSpace(headerRow))
                    {
                        string[] headers = headerRow.Split(',');

                        // Remove any leading/trailing whitespace and handle null or empty headers
                        headers = headers.Select(header => header?.Trim() ?? "Column").ToArray();

                        // Add headers to the DataTable
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header);
                        }

                        while (!reader.EndOfStream)
                        {
                            string[] rows = reader.ReadLine()?.Split(',') ?? new string[0];
                            DataRow dataRow = dataTable.NewRow();
                            dataRow.ItemArray = rows;
                            dataTable.Rows.Add(dataRow);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The header row in the CSV file is null or empty.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTable;
        }
    }
}
