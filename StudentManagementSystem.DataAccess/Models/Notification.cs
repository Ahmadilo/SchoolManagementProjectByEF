using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.DataAccess.Models
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [Required]
        public int SenderID { get; set; }

        [Required]
        public int ReceiverID { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(500)]
        public string Message { get; set; }

        [Required]
        public DateTime SentDate { get; set; } = DateTime.Now;

        public bool? IsRead { get; set; } = false;

        // علاقات التنقل (Navigation Properties)
        [ForeignKey("SenderID")]
        public virtual User Sender { get; set; }

        [ForeignKey("ReceiverID")]
        public virtual User Receiver { get; set; }
    }
}
