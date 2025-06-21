using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class NotificationService
    {
        private static string ErrorStart = "Validation Error: ";

        public static List<string> ValidateNotification(Notification notification)
        {
            var errors = new List<string>();

            if (notification.SenderID <= 0)
                errors.Add(ErrorStart + "SenderID must be a positive integer.");

            if (notification.ReceiverID <= 0)
                errors.Add(ErrorStart + "ReceiverID must be a positive integer.");

            if (string.IsNullOrWhiteSpace(notification.Title))
                errors.Add(ErrorStart + "Title is required.");
            else if (notification.Title.Length > 100)
                errors.Add(ErrorStart + "Title must be 100 characters or less.");

            if (string.IsNullOrWhiteSpace(notification.Message))
                errors.Add(ErrorStart + "Message is required.");
            else if (notification.Message.Length > 500)
                errors.Add(ErrorStart + "Message must be 500 characters or less.");

            if (notification.SentDate > DateTime.Now)
                errors.Add(ErrorStart + "SentDate cannot be in the future.");

            return errors;
        }
    }
}
