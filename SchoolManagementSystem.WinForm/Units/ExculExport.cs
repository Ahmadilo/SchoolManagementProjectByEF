using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace SchoolManagementSystem.WinForm.Units
{
    public class ExculExport
    {
        public static void CreateSimpleExcelFile()
        {
            // تعيين نوع الترخيص (مطلوب في EPPlus 8)
            ExcelPackage.License.SetNonCommercialPersonal("Your Name");

            // مسار الملف الذي سيتم إنشاؤه
            string filePath = @"HelloWorld.xlsx";

            // تأكد من وجود المجلد
            //Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // إنشاء ملف Excel جديد
            using (var package = new ExcelPackage())
            {
                // إنشاء ورقة جديدة
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // كتابة النص في الخلية A1
                worksheet.Cells["A1"].Value = "Hello World";

                // حفظ الملف على القرص
                package.SaveAs(new FileInfo(filePath));
            }

            Console.WriteLine("تم إنشاء الملف بنجاح: " + filePath);
        }
    }

    public class ExcelExporter<T> where T : class
    {
        private readonly ExcelPackage _package;
        private readonly ExcelWorksheet _worksheet;
        private string[] _headers;

        public ExcelExporter()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Ahmad Aden");
            _package = new ExcelPackage();
            _worksheet = _package.Workbook.Worksheets.Add("Sheet1");
        }

        public void SetHeader(string[] headers)
        {
            _headers = headers;
            for (int i = 0; i < headers.Length; i++)
            {
                _worksheet.Cells[1, i + 1].Value = headers[i];
            }
        }

        public void AddData(List<T> data)
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .ToDictionary(p => p.Name, p => p);

            for (int row = 0; row < data.Count; row++)
            {
                var item = data[row];

                for (int col = 0; col < _headers.Length; col++)
                {
                    var header = _headers[col];

                    if (props.TryGetValue(header, out var prop))
                    {
                        var value = prop.GetValue(item);
                        _worksheet.Cells[row + 2, col + 1].Value = value?.ToString() ?? "";
                    }
                }
            }
        }

        public void SaveToFile(string filePath)
        {
            _package.SaveAs(new FileInfo(filePath));
            Console.WriteLine("تم حفظ الملف: " + filePath);
        }
    }
}
