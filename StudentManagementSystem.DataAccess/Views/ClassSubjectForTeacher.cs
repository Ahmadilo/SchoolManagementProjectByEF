using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentManagementSystem.DataAccess.Views
{
    [Table("vw_SubjectsForTeacher")]
    public class ClassSubjectForTeacher
    {
        [Key] // يجب وجود مفتاح، اختر عمود فريد (مثلاً SubjectID)
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public string SubjectCode { get; set; }

        public string Description { get; set; }

        public string Department { get; set; }

        public int TeacherID { get; set; }
    }
}
