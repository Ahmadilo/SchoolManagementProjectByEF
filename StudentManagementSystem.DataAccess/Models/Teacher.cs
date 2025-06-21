using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; } = -1;

        [ForeignKey("Staff"), Required]
        public int StaffID { get; set; }

        [StringLength(100)]
        public string SubjectSpecialization { get; set; }

        // Navigation property to Staff
        public virtual Staff Staff { get; set; }
    }
}
