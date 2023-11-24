using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    internal class GSExcelUtils
    {
        public static List<GoogleSearchExcel> ReadExcelData(string excelFilePath)
        {
            List<GoogleSearchExcel> excelDataList = new List<GoogleSearchExcel>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //dotnet core command

            using(var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {                        
                                    //entire excel workbook will be read 
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {                       
                                        //excel data (all)sheet is read as a table
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        //to read the header in the excel
                        ConfigureDataTable =(_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables["GoogleSearch"];//converting given excel-sheet to table
                    
                    foreach(DataRow row in dataTable.Rows)
                    {
                        GoogleSearchExcel excelData = new()
                        {
                            SearchText = row["searchtext"].ToString(),
                        };
                        excelDataList.Add(excelData);

                    }
                }
            }
            return excelDataList;
        }
    }
}
