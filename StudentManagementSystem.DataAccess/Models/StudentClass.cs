using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{
    [Table("StudentClasses")]
    public class StudentClass
    {
        [Key]
        public int StudentClassID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int ClassID { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        // العلاقات (Navigation Properties)
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

        [ForeignKey("ClassID")]
        public virtual SchoolClass SchoolClass { get; set; }
    }
}
