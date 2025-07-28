using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SchoolManagementSystem.WinForm.Units
{
    public class PdfExporter<T> where T : class
    {
        private string[] _headers;
        private readonly List<T> _data = new List<T>();

        public void SetHeader(string[] headers)
        {
            _headers = headers;
        }

        public void AddData(List<T> data)
        {
            _data.AddRange(data);
        }

        public void SaveToFile(string filePath)
        {
            if (_headers == null || _headers.Length == 0)
                throw new InvalidOperationException("Please Set The Headers of Table.");

            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();

                var table = new PdfPTable(_headers.Length)
                {
                    WidthPercentage = 100
                };

                // إعداد رؤوس الأعمدة
                foreach (var header in _headers)
                {
                    var cell = new PdfPCell(new Phrase(header))
                    {
                        BackgroundColor = BaseColor.LIGHT_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    table.AddCell(cell);
                }

                var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                     .ToDictionary(p => p.Name, p => p);

                // إضافة البيانات
                foreach (var item in _data)
                {
                    foreach (var header in _headers)
                    {
                        if (props.TryGetValue(header, out var prop))
                        {
                            var value = prop.GetValue(item);
                            table.AddCell(value?.ToString() ?? "");
                        }
                        else
                        {
                            table.AddCell(""); // لو الخاصية غير موجودة في الكائن
                        }
                    }
                }

                document.Add(table);
                document.Close();
            }

            Console.WriteLine("تم حفظ الملف PDF: " + filePath);
        }
    }
}
