using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.BusinessLogic.Activates
{
    public class clsGrade : clsBase<clsGrade>
    {
        private readonly GradeService _service = new GradeService();

        public int StudentID { get; set; }
        public int ClassSubjectID { get; set; }
        public string GradeType { get; set; }
        public DateTime GradeDate { get; set; }
        public decimal Score { get; set; }
        public decimal MaxScore { get; set; }
        public decimal Weight { get; set; }
        public string Comments { get; set; }

        public clsGrade()
        {
            GradeDate = DateTime.Now;
            IsNew = true;
        }

        private clsGrade(Grade model)
        {
            FromModel(model);
            IsNew = false;
        }

        private void FromModel(Grade model)
        {
            _id = model.GradeID;
            StudentID = model.StudentID;
            ClassSubjectID = model.ClassSubjectID;
            GradeType = model.GradeType;
            GradeDate = model.GradeDate;
            Score = model.Score;
            MaxScore = model.MaxScore;
            Weight = model.Weight;
            Comments = model.Comments;
        }

        private Grade ToModel()
        {
            return new Grade
            {
                GradeID = _id,
                StudentID = this.StudentID,
                ClassSubjectID = this.ClassSubjectID,
                GradeType = this.GradeType,
                GradeDate = this.GradeDate,
                Score = this.Score,
                MaxScore = this.MaxScore,
                Weight = this.Weight,
                Comments = this.Comments
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = GradeService.ValidateGrade(ToModel());
            return !_ErrorMessages.Any();
        }

        protected override bool DeleteByID(int id)
        {
            return _service.DeleteGrade(id);
        }

        public static bool Delete(int id)
        {
            return new clsGrade().DeleteByID(id);
        }

        protected override clsGrade GetByID(int id)
        {
            var model = _service.GetGradeById(id);
            return model == null ? null : new clsGrade(model);
        }

        public static clsGrade Find(int id)
        {
            return new clsGrade().GetByID(id);
        }

        protected override List<clsGrade> GetAll()
        {
            var list = new List<clsGrade>();
            var models = _service.GetAllGrades();

            foreach (var grade in models)
            {
                if (grade != null)
                    list.Add(new clsGrade(grade));
            }

            return list;
        }

        public static List<clsGrade> GetAllGrades()
        {
            return new clsGrade().GetAll();
        }

        protected override bool _Add()
        {
            var model = ToModel();
            model.GradeID = _service.AddGrade(model);

            if (model.GradeID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add grade.");
                return false;
            }

            FromModel(model);
            return true;
        }

        protected override bool _Update()
        {
            var model = ToModel();
            if (_service.UpdateGrade(model))
            {
                FromModel(model);
                return true;
            }

            _ErrorMessages.Add(_ErrorStart + "Failed to update grade.");
            return false;
        }
    }
}
