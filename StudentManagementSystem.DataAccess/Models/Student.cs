using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; } = -1;

        // مفتاح أجنبي لعلاقة مع كيان Person (الشخص)
        [Required]
        public int PersonID { get; set; }

        [StringLength(20)]
        public string EnrollmentNumber { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        // مفتاح أجنبي يشير إلى الأب (والد الطالب) - قابل لأن يكون فارغاً
        public int? ParentID { get; set; }

        public int? CurrentGradeLevel { get; set; }

        // Navigation Properties

        // الشخص المرتبط بهذا الطالب (مثلاً بيانات الطالب نفسه)
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }

        // الأب أو ولي الأمر (أيضاً كائن من نوع Person)
        [ForeignKey("ParentID")]
        public virtual Person Parent { get; set; }
    }
}
