using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.utilities
{
    internal class ExcelUtils
    {
        public static List<CreateAccount> ReadCreateAccountExcelData(string excelFilePath, string sheetName)
        {
            List<CreateAccount> excelDataList = new List<CreateAccount>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            CreateAccount cAExcelData = new CreateAccount()
                            {
                                FirstName = GetValueOrDefault(row, "firstName"),
                                LastName = GetValueOrDefault(row, "lastName"),
                                Email = GetValueOrDefault(row, "email"),
                                Password = GetValueOrDefault(row, "password"),
                                ConfirmPassword = GetValueOrDefault(row, "confirmPassword"),
                                MobileNumber = GetValueOrDefault(row, "mobileNum")
                            };

                            excelDataList.Add(cAExcelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string? GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }

}

