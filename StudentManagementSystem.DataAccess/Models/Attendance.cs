using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int ClassSubjectID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; }

        [StringLength(200)]
        public string Notes { get; set; }

        // علاقات التنقل
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

        [ForeignKey("ClassSubjectID")]
        public virtual ClassSubject ClassSubject { get; set; }
    }
}
