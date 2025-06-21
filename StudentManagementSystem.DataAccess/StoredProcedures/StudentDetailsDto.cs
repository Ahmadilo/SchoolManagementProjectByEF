using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DataAccess.StoredProcedures
{
    public class StudentDetailsDto
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string EnrollmentNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CurrentGradeLevel { get; set; }
        public string ClassName { get; set; }
        public string AcademicYear { get; set; }

        public static void PrintStudentDetailsHeader()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                $"| {"ID",-6} | {"First Name",-12} | {"Last Name",-12} | {"Gender",-6} | {"Email",-20} | {"Phone",-12} | {"Class",-10} | {"Year",-6} |"
            );
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        }

        public static void PrintStudentDetailsRow(StudentDetailsDto s)
        {
            Console.WriteLine(
                $"| {s.StudentID,-6} | {s.FirstName,-12} | {s.LastName,-12} | {s.Gender,-6} | {s.Email,-20} | {s.Phone,-12} | {s.ClassName ?? "N/A",-10} | {s.AcademicYear ?? "N/A",-6} |"
            );
        }
    }

}
