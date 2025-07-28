using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace StudentManagementSystem.DataAccess
{
    internal static class clsGloble
    {
        public static SqlConnection connection = new SqlConnection("Server=.;Database=SchoolManagementSystem;User Id=sa;Password=sa123456;");
        public static SqlCommand command = connection.CreateCommand();

        public static void FillParametersCommand(string[] Names, object[] Valus)
        {
            command.Parameters.Clear();
            for(int i = 0; i < Names.Length; i++)
            {
                command.Parameters.AddWithValue(Names[i], Valus[i]);
            }
        }
    }

    public static class ExceptionHelper
    {
        public static Exception GetRootException(Exception ex)
        {
            if (ex == null) return null;

            // نحفر داخل InnerException حتى نصل إلى آخر واحدة (الأصلية)
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex;
        }
    }

    public static class Logger
    {
        // المسار الكامل لملف الأخطاء (يمكنك تعديله حسب الحاجة)
        private static readonly string logFilePath = "error_log.txt";

        public static void LogError(string errorMessage)
        {
            try
            {
                // التأكد من وجود الملف، وإن لم يكن موجودًا سيتم إنشاؤه تلقائيًا عند الكتابة باستخدام Append
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine("===== Error Logged at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " =====");
                    writer.WriteLine(errorMessage);
                    writer.WriteLine(); // سطر فارغ للفصل بين الأخطاء
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("فشل في تسجيل الخطأ: " + ex.Message);
            }
        }
    }
}
