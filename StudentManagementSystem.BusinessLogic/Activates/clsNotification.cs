using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.BusinessLogic.Activates
{
    public class clsNotification : clsBase<clsNotification>
    {
        private readonly NotificationService _service = new NotificationService();

        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; } = DateTime.Now;
        public bool? IsRead { get; set; } = false;

        public clsNotification()
        {
            IsNew = true;
        }

        private clsNotification(Notification model)
        {
            FromModel(model);
            IsNew = false;
        }

        private void FromModel(Notification model)
        {
            this._id = model.NotificationID;
            this.SenderID = model.SenderID;
            this.ReceiverID = model.ReceiverID;
            this.Title = model.Title;
            this.Message = model.Message;
            this.SentDate = model.SentDate;
            this.IsRead = model.IsRead;
        }

        private Notification ToModel()
        {
            return new Notification
            {
                NotificationID = _id,
                SenderID = this.SenderID,
                ReceiverID = this.ReceiverID,
                Title = this.Title,
                Message = this.Message,
                SentDate = this.SentDate,
                IsRead = this.IsRead
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = NotificationService.ValidateNotification(ToModel());
            return !_ErrorMessages.Any();
        }

        protected override bool DeleteByID(int id)
        {
            return _service.DeleteNotification(id);
        }

        public static bool Delete(int id)
        {
            return new clsNotification().DeleteByID(id);
        }

        protected override clsNotification GetByID(int id)
        {
            var model = _service.GetNotificationById(id);
            return model == null ? null : new clsNotification(model);
        }

        public static clsNotification Find(int id)
        {
            return new clsNotification().GetByID(id);
        }

        protected override List<clsNotification> GetAll()
        {
            var models = _service.GetAllNotifications();
            var list = new List<clsNotification>();

            foreach (var model in models)
            {
                if (model != null)
                    list.Add(new clsNotification(model));
            }

            return list;
        }

        public static List<clsNotification> GetAllNotifications()
        {
            return new clsNotification().GetAll();
        }

        protected override bool _Add()
        {
            var model = ToModel();
            model.NotificationID = _service.AddNotification(model);

            if (model.NotificationID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add notification.");
                return false;
            }

            FromModel(model);
            return true;
        }

        protected override bool _Update()
        {
            var model = ToModel();
            if (_service.UpdateNotification(model))
            {
                FromModel(model);
                return true;
            }

            _ErrorMessages.Add(_ErrorStart + "Failed to update notification.");
            return false;
        }
    }
}
