using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.BusinessLogic.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.BusinessLogic.Activates;

namespace StudentSystem.UnitTesting.Cases
{
    internal static class clsContainer
    {
        public static HashSet<clsPerson> FakePersons { get; set; } = new HashSet<clsPerson>();

        public static HashSet<clsStudent> FakeStudents { get; set; } = new HashSet<clsStudent>();
    
        public static HashSet<clsSubject> FakeSubjects { get; set; } = new HashSet<clsSubject>();

        public static HashSet<clsSchoolClass> FakeClasses { get; set; } = new HashSet<clsSchoolClass>();

        public static HashSet<clsStudentClass> FakeStudentClass { get; set; } = new HashSet<clsStudentClass>();

        public static HashSet<clsStaff> FakeStaffs { get; set; } = new HashSet<clsStaff>();

        public static HashSet<clsTeacher> FakeTeachers { get; set; } = new HashSet<clsTeacher>();

        public static HashSet<clsClassSubject> FakeClassSubjects { get; set; } = new HashSet<clsClassSubject>();

        public static HashSet<clsGrade> FakeMarks { get; set; } = new HashSet<clsGrade>();
    }
}
