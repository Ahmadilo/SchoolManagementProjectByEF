using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.Views;
using StudentManagementSystem.DataAccess.Services;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Reports
{
    public class clsStudentsReport
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int GradeLevel { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }

        private void FromModle(StudentClassDetails scDetails)
        {
            this.StudentID = scDetails.StudentID;
            this.FirstName = scDetails.FirstName;
            this.LastName = scDetails.LastName;
            this.Phone = scDetails.Phone;
            this.GradeLevel = scDetails.CurrentGradeLevel;
            this.EnrollmentDate = scDetails.EnrollmentDate;
            this.ClassID = scDetails.ClassID;
            this.ClassName = scDetails.ClassName;
        }

        private clsStudentsReport(StudentClassDetails scDetails)
        {
            FromModle(scDetails);
        }

        public static List<clsStudentsReport> GetStudentsReport()
        {
            List<StudentClassDetails> Source = ViewService.GetView<StudentClassDetails>(sc => true);

            if (Source == null || !Source.Any())
                throw new InvalidOperationException("No student class details found.");

            return Source.Select(sc => new clsStudentsReport(sc)).ToList();
        }
    }
}
