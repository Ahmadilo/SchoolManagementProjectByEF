using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnEntityFramwork.ConsoleApp
{
    internal class AssetManpultionTest
    {
        public static void TestSubjectService(string name, string code, string description, string department)
        {
            var subject = new Subject
            {
                SubjectName = name,
                SubjectCode = code,
                Description = description,
                Department = department
            };

            var service = new SubjectService();

            bool isToken = service.IsSubjectCodeTaken(subject.SubjectCode); // Replace with actual token validation logic

            // Add
            int id = service.AddSubject(subject);
            Console.WriteLine(id > 0 ? $"✅ Added with ID: {id}" : "❌ Failed to add.");

            // Get by ID
            var fetched = service.GetSubjectById(id);
            Console.WriteLine(fetched != null ? $"✅ Fetched: {fetched.SubjectName}" : "❌ Fetch failed.");

            // Update
            fetched.SubjectName = "Advanced Mathematics";
            bool updated = service.UpdateSubject(fetched);
            Console.WriteLine(updated ? "✅ Update succeeded." : "❌ Update failed.");

            // Delete
            bool deleted = service.DeleteSubject(id);
            Console.WriteLine(deleted ? "✅ Delete succeeded." : "❌ Delete failed.");
        }

        public static void TestSchoolClassService(string name, int grade, string academicyear, int teacherid)
        {
            var schoolClass = new SchoolClass
            {
                ClassName = name,
                GradeLevel = grade,
                AcademicYear = academicyear,
                HomeroomTeacherID = teacherid // تأكد أن المدرس موجود
            };

            var service = new SchoolClassService();

            // Add
            int id = service.AddClass(schoolClass);
            Console.WriteLine(id > 0 ? $"✅ Added with ID: {id}" : "❌ Failed to add.");

            // Get by ID
            var fetched = service.GetClassById(id);
            Console.WriteLine(fetched != null ? $"✅ Fetched: {fetched.ClassName}" : "❌ Fetch failed.");

            // Update
            fetched.ClassName = "Class B";
            bool updated = service.UpdateClass(fetched);
            Console.WriteLine(updated ? "✅ Update succeeded." : "❌ Update failed.");

            // Delete
            bool deleted = service.DeleteClass(id);
            Console.WriteLine(deleted ? "✅ Delete succeeded." : "❌ Delete failed.");
        }

    }
}
