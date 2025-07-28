using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Views
{
    [Table("vw_StudentClassDetails")]
    public class StudentClassDetails
    {
        //s.StudentID,
        [Key] // يجب وجود مفتاح، اختر عمود فريد (مثلاً StudentID)
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int CurrentGradeLevel { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public int ClassID { get; set; }

        public string ClassName { get; set; }
    }
}
