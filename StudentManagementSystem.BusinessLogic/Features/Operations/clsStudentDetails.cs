using StudentManagementSystem.DataAccess.StoredProcedures;
using StudentManagementSystem.DataAccess.Services.ProcedureServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Operations
{
    public class clsStudentDetails
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

        private void FromModle(StudentDetailsDto studentDetails)
        {
            this.StudentID = studentDetails.StudentID;
            this.FirstName = studentDetails.FirstName;
            this.LastName = studentDetails.LastName;
            this.DateOfBirth = studentDetails.DateOfBirth;
            this.Gender = studentDetails.Gender;
            this.Email = studentDetails.Email;
            this.Phone = studentDetails.Phone;
            this.Address = studentDetails.Address;
            this.EnrollmentNumber = studentDetails.EnrollmentNumber;
            this.EnrollmentDate = studentDetails.EnrollmentDate;
            this.CurrentGradeLevel = studentDetails.CurrentGradeLevel;
            this.ClassName = studentDetails.ClassName;
            this.AcademicYear = studentDetails.AcademicYear;
        }

        private clsStudentDetails(StudentDetailsDto s)
        {
            FromModle(s);
        }

        public static List<clsStudentDetails> GetAllStudentDetails()
        {
            List<clsStudentDetails> studentDetailsList = new List<clsStudentDetails>();
            var studentDetailsDtos = StudentDetailsDtoService.GetAllStudentDetails();// Assuming this method exists in the DTO class

            foreach (var studentDetails in studentDetailsDtos)
            {
                studentDetailsList.Add(new clsStudentDetails(studentDetails));
            }

            return studentDetailsList;
        }
    }
}
