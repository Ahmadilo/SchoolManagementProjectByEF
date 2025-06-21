using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class NotificationService
    {
        public int AddNotification(Notification notification)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Notifications.Add(notification);
                    db.SaveChanges();
                    return notification.NotificationID;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateNotification(Notification updatedNotification)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existing = db.Notifications.Find(updatedNotification.NotificationID);
                    if (existing == null) return false;

                    existing.SenderID = updatedNotification.SenderID;
                    existing.ReceiverID = updatedNotification.ReceiverID;
                    existing.Title = updatedNotification.Title;
                    existing.Message = updatedNotification.Message;
                    existing.SentDate = updatedNotification.SentDate;
                    existing.IsRead = updatedNotification.IsRead;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteNotification(int notificationId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var entity = db.Notifications.Find(notificationId);
                    if (entity == null) return false;

                    db.Notifications.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Notification GetNotificationById(int notificationId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Notifications.FirstOrDefault(n => n.NotificationID == notificationId);
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Notification> GetAllNotifications()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Notifications.ToList();
                }
            }
            catch
            {
                return new List<Notification>();
            }
        }

        public bool DoesNotificationExist(int notificationId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Notifications.Any(n => n.NotificationID == notificationId);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
