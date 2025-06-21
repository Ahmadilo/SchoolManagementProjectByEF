using StudentManagementSystem.BusinessLogic.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnEntityFramwork.ConsoleApp
{
    internal class AssetObjectTest
    {
        public static void TestSubjectCRUD(string name, string code, string description, string department)
        {
            Console.WriteLine("🔍 Starting Subject CRUD Test...");

            // إنشاء كائن جديد من clsSubject
            var subject = new clsSubject
            {
                SubjectName = name,
                SubjectCode = code,
                Description = description,
                Department = department
            };

            // ✅ إضافة
            if (!subject.Validate())
            {
                Console.WriteLine("❌ Validation failed:");
                foreach (var error in subject.ErrorMessages)
                    Console.WriteLine(" - " + error);
                return;
            }

            bool added = subject.Save();

            if (!added)
            {
                Console.WriteLine("❌ Failed to add subject:");
                foreach (var error in subject.ErrorMessages)
                    Console.WriteLine(" - " + error);
                return;
            }

            Console.WriteLine($"✅ Subject added with ID: {subject.ID}");

            // ✅ تحديث
            subject.SubjectName += " [Updated]";
            bool updated = subject.Save();

            if (updated)
                Console.WriteLine("✅ Subject updated successfully.");
            else
            {
                Console.WriteLine("❌ Failed to update subject:");
                foreach (var error in subject.ErrorMessages)
                    Console.WriteLine(" - " + error);
            }

            // ✅ جلب
            var fetched = clsSubject.Find(subject.ID);

            if (fetched != null)
                Console.WriteLine($"✅ Subject fetched: {fetched.SubjectName}");
            else
                Console.WriteLine("❌ Failed to fetch subject.");

            // ✅ حذف
            if (clsSubject.Delete(subject.ID))
                Console.WriteLine("✅ Subject deleted successfully.");
            else
                Console.WriteLine("❌ Failed to delete subject.");
        }

        public static void TestSchoolClassCRUD(string className, int gradeLevel, string academicYear, int? teacherId)
        {
            Console.WriteLine("🔍 Starting SchoolClass CRUD Test...");

            // إنشاء كائن جديد من clsSchoolClass
            var schoolClass = new clsSchoolClass
            {
                ClassName = className,
                GradeLevel = gradeLevel,
                AcademicYear = academicYear,
                TeacherID = teacherId
            };

            // ✅ التحقق
            if (!schoolClass.Validate())
            {
                Console.WriteLine("❌ Validation failed:");
                foreach (var error in schoolClass.ErrorMessages)
                    Console.WriteLine(" - " + error);
                return;
            }

            // ✅ الإضافة
            bool added = schoolClass.Save();

            if (!added)
            {
                Console.WriteLine("❌ Failed to add school class:");
                foreach (var error in schoolClass.ErrorMessages)
                    Console.WriteLine(" - " + error);
                return;
            }

            Console.WriteLine($"✅ Class added with ID: {schoolClass.ID}");

            // ✅ التحديث
            schoolClass.ClassName += " [Updated]";
            bool updated = schoolClass.Save();

            if (updated)
                Console.WriteLine("✅ Class updated successfully.");
            else
            {
                Console.WriteLine("❌ Failed to update class:");
                foreach (var error in schoolClass.ErrorMessages)
                    Console.WriteLine(" - " + error);
            }

            // ✅ الجلب
            var fetched = clsSchoolClass.Find(schoolClass.ID);

            if (fetched != null)
                Console.WriteLine($"✅ Class fetched: {fetched}");
            else
                Console.WriteLine("❌ Failed to fetch class.");

            // ✅ الحذف
            if (clsSchoolClass.Delete(schoolClass.ID))
                Console.WriteLine("✅ Class deleted successfully.");
            else
                Console.WriteLine("❌ Failed to delete class.");
        }

    }
}
