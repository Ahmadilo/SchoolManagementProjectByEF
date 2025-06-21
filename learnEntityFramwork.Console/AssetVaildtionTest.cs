using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.Services;
using StudentManagementSystem.DataAccess.Models;

namespace learnEntityFramwork.ConsoleApp
{
    internal static class AssetVaildtionTest
    {
        public static void TestValidationOfSchoolClass(string classname, int gradelevel, string academicyear, int? teacherid, int ID = -1)
        {
            var testClass = new SchoolClass
            {
                ClassID = ID,
                ClassName = classname,
                GradeLevel = gradelevel,   
                AcademicYear = academicyear, 
                HomeroomTeacherID = teacherid 
            };

            List<string> errors = SchoolClassService.ValidateSchoolClass(testClass);

            if (errors.Count > 0)
            {
                Console.WriteLine("Validation Errors:");
                foreach (var error in errors)
                    Console.WriteLine("- " + error);
            }
            else
            {
                Console.WriteLine("School class is valid.");
            }
        }

        public static void TestValidationOfSubject(string subjectname, string code, string description, string department, int ID = -1)
        {
            var subjectWithErrors = new Subject
            {
                SubjectID = ID,
                SubjectName = subjectname, // خطأ: فارغ
                SubjectCode = code, // خطأ: أطول من 20
                Description = description, // خطأ: أطول من 500
                Department = department // خطأ: أطول من 50
            };

            List<string> errors = SubjectService.SubjectValidationBasic(subjectWithErrors);

            if (errors.Count > 0)
            {
                Console.WriteLine("❌ Validation Errors in subjectWithErrors:");
                foreach (var error in errors)
                    Console.WriteLine("- " + error);
            }
            else
            {
                Console.WriteLine("✅ subjectWithErrors is valid.");
            }

            //Console.WriteLine("\n---\n");

            //var validSubject = new Subject
            //{
            //    SubjectName = "Mathematics",
            //    SubjectCode = "MATH101",
            //    Description = "Basic math for grade 1",
            //    Department = "Mathematics"
            //};

            //var validErrors = SubjectService.SubjectValidationBasic(validSubject);

            //if (validErrors.Count > 0)
            //{
            //    Console.WriteLine("❌ Validation Errors in validSubject:");
            //    foreach (var error in validErrors)
            //        Console.WriteLine("- " + error);
            //}
            //else
            //{
            //    Console.WriteLine("✅ validSubject is valid.");
            //}
        }
    }
}
