using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.Services;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Views;


namespace learnEntityFramwork.ConsoleApp
{
    public static class TeacherUX
    {
        public static void DisplayTeacherClasses()
        {
            List<SchoolClass> TeacherClasses = new SchoolClassService().GetClassesByExpression(c => c.HomeroomTeacherID == 2012);

            if(TeacherClasses.Count > 0)
            {
                Console.WriteLine("Classes for Teacher ID 2012:");
                foreach (var schoolClass in TeacherClasses)
                {
                    Console.WriteLine($"Class ID: {schoolClass.ClassID}, Class Name: {schoolClass.ClassName}, Grade Level: {schoolClass.GradeLevel}, Academic Year: {schoolClass.AcademicYear}");
                }
            }
            else
            {
                Console.WriteLine("No classes found for Teacher ID 2012.");
            }
        }

        public static void DisplayTeacherSubjects()
        {
            List<ClassSubjectForTeacher> SubjectsForTeacher = ViewService.GetSubjectsForTeacher(s => s.TeacherID == 2012);
        
            if(SubjectsForTeacher != null)
            {
                Console.WriteLine("The Count of Subject of Teacher 2012 is: " + SubjectsForTeacher.Count);
            }
        }
    }
}
