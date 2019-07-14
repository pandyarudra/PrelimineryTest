using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrelimineryTest.Services
{
    public class TableInsertionService
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ReadFiles();
            // ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
        }

        public static string[] ReadFiles()
        {
            //Get the headers
            //var lines = File.ReadLines(textBox1.Text);
            DirectoryInfo taskDirectory = new DirectoryInfo(@"C:\Users\rpandya\Downloads\zips\CollegeScorecard_Raw_Data\CollegeScorecard_Raw_Data");

            var files = taskDirectory.GetFiles("*.csv").Where(p => p.Name.StartsWith("MERGED"));
            var firstFile = files.First();
            var firstFileLines = File.ReadAllLines(firstFile.FullName);
            var columns = firstFileLines[0].Split(',');
            var allYears = files.ToList().Select(x => {
                var startIndex = x.Name.IndexOf('D') + 1;
                var lastIndex = x.Name.Count() - 13;
                var result = x.Name.Substring(startIndex, lastIndex);
                return result;
            });
            var sqlStringToCreateTable = "CREATE TABLE MergedFilesTable ( ";
            var sb = new StringBuilder();
            var i = 0;
            var totalColumns = columns.Count();
            foreach (var column in columns)
            {
                var columnText = column + " nvarchar(80) NULL";
                if (i == totalColumns - 1)
                {
                    sb.Append(columnText + " )");

                }
                else
                {
                    if (i >= 7)
                    {
                        columnText = column + " nvarchar(80) SPARSE NULL";
                    }
                    sb.Append(columnText + ", ");
                }
                i++;
            }
            sqlStringToCreateTable = sqlStringToCreateTable + sb.ToString();
            //List<string> headerRow = lines.ElementAt(0).Split(',').ToList();
            //foreach (string header in headerRow)
            //{
            //    //Create table etc.......
            //}
            //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringNameFromWebConfig"].ConnectionString);
            return allYears.ToArray();
        }
    }
}
