using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace StudentManagementSystem.DataAccess.Models
{
    [Table("ClassSubjects")]
    public class ClassSubject
    {
        [Key]
        public int ClassSubjectID { get; set; }

        [Required]
        public int ClassID { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required, StringLength(10)]
        public string ScheduleDay { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [StringLength(20)]
        public string RoomNumber { get; set; }

        // علاقات التنقل (Navigation Properties)
        [ForeignKey("ClassID")]
        public virtual SchoolClass Class { get; set; }

        [ForeignKey("SubjectID")]
        public virtual Subject Subject { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher Teacher { get; set; }
    }
}
