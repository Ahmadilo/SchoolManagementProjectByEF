using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DataAccess.Views
{
    [Table("vw_StudentByClass")]
    public class StudentsByClass
    {
        [Key]
        public int ClassID { get; set; }

        public string ClassName { get; set; }

        public int GradeLevel { get; set; }

        public string AcademicYear { get; set; }


        public int StudentID { get; set; }

        public int PersonID { get; set; }

        public string FullName { get; set; }

        public int CurrentGradeLevel { get; set; }
    }

}
