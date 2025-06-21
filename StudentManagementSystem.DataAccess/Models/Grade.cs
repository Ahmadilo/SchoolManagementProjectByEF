using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{
    [Table("Grades")]
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int ClassSubjectID { get; set; }

        [Required, StringLength(20)]
        public string GradeType { get; set; }

        [Required]
        public DateTime GradeDate { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Score { get; set; }

        [Required]
        [Range(0,100)]
        public decimal MaxScore { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Weight { get; set; }

        [StringLength(200)]
        public string Comments { get; set; }

        // علاقات التنقل (Navigation Properties)
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

        [ForeignKey("ClassSubjectID")]
        public virtual ClassSubject ClassSubject { get; set; }
    }
}
