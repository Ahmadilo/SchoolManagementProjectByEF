using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;

namespace StudentManagementSystem.BusinessLogic.Assets
{
    public class clsSchoolClass : clsBase<clsSchoolClass>
    {
        private readonly SchoolClassService _schoolClassService = new SchoolClassService();

        public string ClassName { get; set; }
        public int GradeLevel { get; set; }
        public string AcademicYear { get; set; }
        public int? TeacherID { get; set; }

        public clsSchoolClass()
        {
            IsNew = true;
        }

        private clsSchoolClass(SchoolClass model)
        {
            FromModel(model);
            IsNew = false;
        }

        private SchoolClass ToModel()
        {
            return new SchoolClass
            {
                ClassID = _id,
                ClassName = this.ClassName,
                GradeLevel = this.GradeLevel,
                AcademicYear = this.AcademicYear,
                HomeroomTeacherID = this.TeacherID
            };
        }

        private void FromModel(SchoolClass model)
        {
            _id = model.ClassID;
            ClassName = model.ClassName;
            GradeLevel = model.GradeLevel;
            AcademicYear = model.AcademicYear;
            TeacherID = model.HomeroomTeacherID;
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = SchoolClassService.ValidateSchoolClass(ToModel());
            return !_ErrorMessages.Any();
        }

        protected override bool _Add()
        {
            var model = ToModel();
            model.ClassID = _schoolClassService.AddClass(model);

            if (model.ClassID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add class.");
                return false;
            }

            FromModel(model);
            return true;
        }

        protected override bool _Update()
        {
            var model = ToModel();

            if (_schoolClassService.UpdateClass(model))
            {
                FromModel(model);
                return true;
            }

            _ErrorMessages.Add(_ErrorStart + "Failed to update class. Please check data.");
            return false;
        }

        protected override bool DeleteByID(int id)
        {
            return _schoolClassService.DeleteClass(id);
        }

        protected override clsSchoolClass GetByID(int id)
        {
            var model = _schoolClassService.GetClassById(id);
            if (model == null) return null;

            return new clsSchoolClass(model);
        }

        protected override List<clsSchoolClass> GetAll()
        {
            var list = _schoolClassService.GetAllClasses();
            var result = new List<clsSchoolClass>();

            foreach (var model in list)
            {
                if (model != null)
                    result.Add(new clsSchoolClass(model));
            }

            return result;
        }

        public static clsSchoolClass Find(int id)
        {
            return new clsSchoolClass().GetByID(id);
        }

        public static List<clsSchoolClass> GetAllClasses()
        {
            return new clsSchoolClass().GetAll();
        }

        public static bool Delete(int id)
        {
            return new clsSchoolClass().DeleteByID(id);
        }

        public override string ToString()
        {
            return $"{ClassName} - Grade {GradeLevel} - {AcademicYear}";
        }

        public static List<clsSchoolClass> GetClassesByTeacher(int teacherId)
        {
            if (teacherId <= 0)
                throw new ArgumentException("The TeacherID is not can be 0 or less then", nameof(teacherId));

            List<SchoolClass> list = new SchoolClassService().GetClassesByExpression(sc => sc.HomeroomTeacherID == teacherId);
            List<clsSchoolClass> result = new List<clsSchoolClass>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(new clsSchoolClass(list[i]));
            }

            return result;
        }

        public static List<clsSchoolClass> GetClassesForStudent(int studentID)
        {
            return clsStudentClass.GetAllStudentClasses()
                                  .Where(sc => sc.StudentID == studentID)
                                  .Select(sc => clsSchoolClass.Find(sc.ClassID))
                                  .ToList();
        }
    }
}
