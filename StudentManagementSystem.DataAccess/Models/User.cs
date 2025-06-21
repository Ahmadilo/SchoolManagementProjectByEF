using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{

    [Table("Users")] // يربط الكلاس بالجدول مباشرة
    public class User
    {
        [Key]
        public int UserID { get; set; } = -1;

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }

        [Required, StringLength(20)]
        public string Role { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool? IsActive { get; set; }
    }
}
