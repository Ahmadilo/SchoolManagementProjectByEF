using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{
    [Table("Staff")] // يربط الكلاس بالجدول مباشرة
    public class Staff
    {
        [Key]
        public int StaffID { get; set; } = -1;

        [Required]
        public int PersonID { get; set; }

        [MaxLength(20)]
        public string StaffNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        [MaxLength(50)]
        public string Position { get; set; }

        [MaxLength(50)]
        public string Department { get; set; }

        [Range(0, 9999999999.99)]
        public decimal? Salary { get; set; }

        // العلاقات
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    }
}
