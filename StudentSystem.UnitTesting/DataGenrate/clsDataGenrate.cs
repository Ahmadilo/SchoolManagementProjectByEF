using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.BusinessLogic.Features.Roles;
using StudentSystem.UnitTesting.Cases;

namespace StudentSystem.UnitTesting.DataGenrate
{
    internal static class clsDataGenrate
    {
        public static clsPerson GenratePerson(
            string FirstName = "John",
            string LastName = "Doe", string Date = "2000-1-1",
            string Address = "123 Main St, Springfield, USA",
            string Email = "John@gmail.com",
            int? UserID = null,
            string Gender = "Male",
            string Phone = "#"
        )
        {
            var newPerson = new clsPerson();

            newPerson.FirstName = FirstName;
            newPerson.LastName = LastName;
            newPerson.DateOfBirth = Convert.ToDateTime(Date);
            newPerson.Address = Address;
            newPerson.Email = Email;
            newPerson.UserID = UserID;
            newPerson.Gender = Gender;
            if(Phone == "#")
            {
                newPerson.PhoneNumber = "063" + Guid.NewGuid().ToString("N").Substring(0, 7);
            }
            else
            {
                newPerson.PhoneNumber = Phone;
            }

            if (!newPerson.Save())
                throw new Exception(newPerson.ErrorMessages.FirstOrDefault());

            clsContainer.FakePersons.Add(newPerson);

            return newPerson;
        }

        public static clsStudent GenrateStudent(
            int PersonID = -1,
            string EnrollmentNumber = "#",
            int CurrentGradeLevel = 1,
            string Date = "#",
            int ParentID = -1
        )
        {
            clsStudent newStudent = new clsStudent();
            if (PersonID == -1)
                newStudent.PersonID = GenratePerson().ID;
            newStudent.PersonID = PersonID;
            if (EnrollmentNumber == "#")
                newStudent.EnrollmentNumber = "ENT-" + Guid.NewGuid().ToString("N").Substring(0, 12);
            else
                newStudent.EnrollmentNumber = EnrollmentNumber;
            newStudent.CurrentGradeLevel = CurrentGradeLevel;

            if (Date == "#")
                newStudent.EnrollmentDate = DateTime.Today;
            else
                newStudent.EnrollmentDate = Convert.ToDateTime(Date);

            if (!newStudent.Save())
                throw new Exception(newStudent.ErrorMessages.FirstOrDefault());

            clsContainer.FakeStudents.Add(newStudent);

            return newStudent;
        }

        public static clsSubject GenrateSubject(
            string Subject = "SubjectName",
            string SubjectCode = "#",
            string Departemnt = "#",
            string Description = "Description of the subject"
        )
        {
            clsSubject newSubject = new clsSubject();

            newSubject.SubjectName = Subject;
            if (SubjectCode == "#")
                newSubject.SubjectCode = Subject.Substring(0,1) + Guid.NewGuid().ToString("N").Substring(0, 3);
            else
                newSubject.SubjectCode = SubjectCode;
            newSubject.Department = Departemnt;
            newSubject.Description = Description;

            if (!newSubject.Save())
                throw new Exception(newSubject.ErrorMessages.FirstOrDefault());

            clsContainer.FakeSubjects.Add(newSubject);
            return newSubject;
        }

        public static clsSchoolClass GenrateClass(
            string ClassName = "Math 101",
            int Level = 1,
            string AcademicYear = "2023-2024"
        )
        {
            clsSchoolClass newClass = new clsSchoolClass();

            newClass.ClassName = ClassName;
            newClass.GradeLevel = Level;
            newClass.AcademicYear = AcademicYear;

            if (!newClass.Save())
                throw new Exception(newClass.ErrorMessages.FirstOrDefault());

            clsContainer.FakeClasses.Add(newClass);

            return newClass;
        }

        public static clsStudentClass GenrateStudentClass(
            int StudentID = -1,
            int ClassID = -1
        )
        {
            clsStudentClass classStudents = new clsStudentClass();
            if (StudentID == -1)
                classStudents.StudentID = GenrateStudent().ID;
            else
                classStudents.StudentID = StudentID;
            if (ClassID == -1)
                classStudents.ClassID = GenrateClass().ID;
            else
                classStudents.ClassID = ClassID;

            if (!classStudents.Save())
                throw new Exception(classStudents.ErrorMessages.FirstOrDefault());
            clsContainer.FakeStudentClass.Add(classStudents);

            return classStudents;
        }

        public static clsStaff GenrateStaff(
            int PersonID = -1,
            string Department = "General Department",
            string StaffNumber = "#"
        )
        {
            clsStaff newStaff = new clsStaff();

            if (PersonID == -1)
                newStaff.PersonID = GenratePerson().ID;
            else
                newStaff.PersonID = PersonID;

            newStaff.Department = Department;

            if (StaffNumber == "#")
                newStaff.StaffNumber = "STF-" + new Random().Next(1000, 9999).ToString();
            else
                newStaff.StaffNumber = StaffNumber;

            if (!newStaff.Save())
                throw new Exception(newStaff.ErrorMessages.FirstOrDefault());

            clsContainer.FakeStaffs.Add(newStaff);

            return newStaff;
        }

        public static clsTeacher GenrateTeacher(
            int StaffID = -1,
            string Subject = "Subject"
        )
        {
            clsTeacher newTeacher = new clsTeacher();
            if (StaffID == -1)
                newTeacher.StaffID = GenrateStaff().ID;
            else
                newTeacher.StaffID = StaffID;
            newTeacher.SubjectSpecialization = Subject;

            if (!newTeacher.Save())
                throw new Exception(newTeacher.ErrorMessages.FirstOrDefault());

            clsContainer.FakeTeachers.Add(newTeacher);

            return newTeacher;
        }

        public static clsClassSubject GenrateClassSubject(
            int SubjectID = -1,
            int ClassID = -1,
            string ScheduleDay = "Monday",
            string StartTime = "#",
            string EndTime = "#",
            int TeacherID = -1
        )
        {
            clsClassSubject classSubject = new clsClassSubject();

            if (SubjectID == -1)
                classSubject.SubjectID = GenrateSubject().ID;
            else
                classSubject.SubjectID = SubjectID;

            if (ClassID == -1)
                classSubject.ClassID = GenrateClass().ID;
            else
                classSubject.ClassID = ClassID;

            classSubject.ScheduleDay = ScheduleDay;

            if(StartTime == "#")
                classSubject.StartTime = new TimeSpan(8, 0, 0); // Default start time at 8 AM
            else
                classSubject.StartTime = TimeSpan.Parse(StartTime);// Just a simple way to vary start time
            
            if(EndTime == "#")
                classSubject.EndTime = new TimeSpan(9, 0, 0); // Default end time at 9 AM
            else
                classSubject.EndTime = TimeSpan.Parse(EndTime);// Just a simple way to vary end time

            if (TeacherID == -1)
                classSubject.TeacherID = GenrateTeacher().ID;
            else
                classSubject.TeacherID = TeacherID;

            if (!classSubject.Save())
                throw new Exception(classSubject.ErrorMessages.FirstOrDefault());

            clsContainer.FakeClassSubjects.Add(classSubject);

            return classSubject;
        }

        public static clsGrade GenrateGrade(
            int StudentID = -1,
            int ClassSubjectID = -1,
            string GradeType = "Test",
            string Date = "#",
            decimal Score = 90,
            decimal MaxScore = 10,
            decimal Weight = 50
        )
        {
            clsGrade newMark = new clsGrade();

            if (StudentID == -1)
                newMark.StudentID = GenrateStudent().ID;
            else
                newMark.StudentID = StudentID;

            if (ClassSubjectID == -1)
                newMark.ClassSubjectID = GenrateClassSubject().ID;
            else
                newMark.ClassSubjectID = ClassSubjectID;


            newMark.GradeType = GradeType;

            if (Date == "#")
                newMark.GradeDate = DateTime.Today.AddDays(new Random().Next(-1000, -10));
            else
                newMark.GradeDate = Convert.ToDateTime(Date);


            newMark.Score = Score; // Random score between 0 and MaxScore
            newMark.MaxScore = MaxScore;
            newMark.Weight = Weight;

            if (!newMark.Save())
                throw new Exception(newMark.ErrorMessages.FirstOrDefault());

            clsContainer.FakeMarks.Add(newMark);

            return newMark;
        }

        public static (string TypeName, int Weight, int MaxScore)[] TypesMarks =
            clsGradesRoles
            .GradeTypeRoles
            .Select(
                r =>
                {
                    return (
                        TypeName: r.Key.ToString(),
                        r.Value.Weight,
                        r.Value.MaxScore);
                }
            )
            .ToArray();
    }
}
