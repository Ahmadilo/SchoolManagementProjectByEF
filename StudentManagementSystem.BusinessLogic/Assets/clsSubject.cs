using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.BusinessLogic.Assets
{
    public class clsSubject : clsBase<clsSubject>
    {
        private readonly SubjectService _subjectService = new SubjectService();

        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }

        public clsSubject()
        {
            IsNew = true;
        }

        private clsSubject(Subject subject)
        {
            FromModel(subject);
            IsNew = false;
        }

        private void FromModel(Subject subject)
        {
            this._id = subject.SubjectID;
            this.SubjectName = subject.SubjectName;
            this.SubjectCode = subject.SubjectCode;
            this.Description = subject.Description;
            this.Department = subject.Department;
        }

        private Subject ToModel()
        {
            return new Subject
            {
                SubjectID = _id,
                SubjectName = this.SubjectName,
                SubjectCode = this.SubjectCode,
                Description = this.Description,
                Department = this.Department
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = SubjectService.SubjectValidationBasic(ToModel());
            return !_ErrorMessages.Any();
        }

        protected override bool DeleteByID(int id)
        {
            return _subjectService.DeleteSubject(id);
        }

        public static bool Delete(int id)
        {
            return new clsSubject().DeleteByID(id);
        }

        protected override clsSubject GetByID(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            return subject == null ? null : new clsSubject(subject);
        }

        public static clsSubject Find(int id)
        {
            return new clsSubject().GetByID(id);
        }

        protected override List<clsSubject> GetAll()
        {
            var modelSubjects = _subjectService.GetAllSubjects();
            var list = new List<clsSubject>();

            foreach (var subject in modelSubjects)
            {
                if (subject != null)
                    list.Add(new clsSubject(subject));
            }

            return list;
        }

        public static List<clsSubject> GetAllSubjects()
        {
            return new clsSubject().GetAll();
        }

        protected override bool _Add()
        {
            var subject = ToModel();
            subject.SubjectID = _subjectService.AddSubject(subject);

            if (subject.SubjectID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add subject.");
                return false;
            }

            FromModel(subject);
            return true;
        }

        protected override bool _Update()
        {
            var subject = ToModel();
            if (_subjectService.UpdateSubject(subject))
            {
                FromModel(subject);
                return true;
            }

            _ErrorMessages.Add(_ErrorStart + "Failed to update subject.");
            return false;
        }
    }
}
