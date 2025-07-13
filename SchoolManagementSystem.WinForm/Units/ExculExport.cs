using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
}
