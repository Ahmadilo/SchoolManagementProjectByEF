using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;

namespace StudentManagementSystem.BusinessLogic.Humans
{
    public class clsStudent : clsBase<clsStudent>
    {
        private readonly StudentService _studentService = new StudentService();
        private clsPerson _person = null;
        private clsPerson _parent = null;

        public int PersonID { get; set; }
        public clsPerson Person
        {
            get
            {
                return clsPublic.GetInstansOfID(PersonID, _person);
            }
        }
        public string EnrollmentNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int? ParentID { get; set; } = null;
        public clsPerson Parent
        {
            get
            {
                if (ParentID == null || ParentID == -1)
                    return null;
                return clsPublic.GetInstansOfID(ParentID.Value, _parent);
            }
        }
        public int CurrentGradeLevel { get; set; }
        public string FullName { get { return clsPerson.Find(PersonID).FullName; } }
        public List<clsGrade> Grades
        {
            get
            {
                return clsGrade.GetAllGrades().Where(g => g.StudentID == this.ID).ToList();
            }
        }

        public clsStudent()
        {
            IsNew = true;
        }

        private clsStudent(Student student)
        {
            ModelStudentToclsStudent(student);
            IsNew = false;
        }

        protected override bool DeleteByID(int id)
        {
            return _studentService.DeleteStudent(id);
        }

        public static bool Delete(int id)
        {
            return new clsStudent().DeleteByID(id);
        }

        protected override clsStudent GetByID(int id)
        {
            Student student = _studentService.GetStudentById(id);

            if (student == null)
                return null;

            clsStudent Student = new clsStudent(student);

            return Student;
        }

        public static clsStudent Find(int id)
        {
            return new clsStudent().GetByID(id);
        }

        protected override List<clsStudent> GetAll()
        {
            List<Student> modelStudents = _studentService.GetAllStudents();

            if(modelStudents == null)
                return new List<clsStudent>();

            if(modelStudents.Count == 0)
                return new List<clsStudent>();

            List<clsStudent> StudentList = new List<clsStudent>();

            for(int i = 0; i < modelStudents.Count; i++)
            {
                Student student = modelStudents[i];

                if (student == null)
                    continue;

                clsStudent Student = new clsStudent(student);

                StudentList.Add(Student);
            }

            return StudentList;
        }

        public static List<clsStudent> GetAllStudent()
        {
            return new clsStudent().GetAll();
        }

        private Student ClsStudentToStudent()
        {
            return new Student
            {
                StudentID = _id,
                PersonID = this.PersonID,
                EnrollmentNumber = this.EnrollmentNumber,
                EnrollmentDate = this.EnrollmentDate,
                ParentID = this.ParentID,
                CurrentGradeLevel = this.CurrentGradeLevel
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = StudentService.StudentValidationBasic(ClsStudentToStudent());
            return !_ErrorMessages.Any();
        }

        private void ModelStudentToclsStudent(Student student)
        {
            //public int PersonID { get; set; }
            //public string EnrollmentNumber { get; set; }
            //public DateTime EnrollmentDate { get; set; }
            //public int ParentID { get; set; }
            //public int CurrentGradeLevel { get; set; }

            this._id = student.StudentID;
            this.PersonID = student.PersonID;
            this.EnrollmentNumber = student.EnrollmentNumber;
            this.EnrollmentDate = student.EnrollmentDate ?? DateTime.MinValue;
            this.ParentID = student.ParentID ?? -1;
            this.CurrentGradeLevel = student.CurrentGradeLevel ?? -1;
        }

        protected override bool _Add()
        {
            Student student = ClsStudentToStudent();

            student.StudentID = _studentService.AddStudent(student);

            if(student.StudentID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Faild To add Student.");
                return false;
            }

            ModelStudentToclsStudent(student);

            return true;
        }

        protected override bool _Update()
        {
            Student student = ClsStudentToStudent();

            if(_studentService.UpdateStudent(student))
            {
                ModelStudentToclsStudent(student);
                return true;
            }
            else
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to update student. Please check the data and try again.");
                return false;
            }
        }

        public static List<clsStudent> GetAllStudentsNotInClasses()
        {
            List<Student> students = new clsStudent()._studentService.GetAllStudentInNotClasses();
            if(students == null || students.Count == 0)
                return new List<clsStudent>();
            return students.Select(s => new clsStudent(s)).ToList();
        }

        public static List<clsStudent> GetAllStudentInClass(int ClassID)
        {
            int[] StudentIDs = clsStudentClass.GetAllStudentClasses().Where(sc => sc.ClassID == ClassID).Select(sc => sc.StudentID).ToArray();
            return GetAllStudent().Where(s => StudentIDs.Contains(s.ID)).ToList();
        }
    }
}
