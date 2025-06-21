using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{
    [Table("Classes")]
    public class SchoolClass
    {
        [Key]
        public int ClassID { get; set; }

        [Required, StringLength(50)]
        public string ClassName { get; set; }

        [Required, Range(0, 12)]
        public int GradeLevel { get; set; }

        [Required, StringLength(20)]
        public string AcademicYear { get; set; }

        public int? HomeroomTeacherID { get; set; }

        [ForeignKey("HomeroomTeacherID")]
        public virtual Teacher Teacher { get; set; }
    }
}
