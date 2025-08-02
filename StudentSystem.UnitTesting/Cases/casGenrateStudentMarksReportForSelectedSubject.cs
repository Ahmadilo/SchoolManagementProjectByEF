using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.BusinessLogic.Features.Roles;
using System.Diagnostics;
using StudentSystem.UnitTesting.BuesinessLogic;

namespace StudentSystem.UnitTesting.Cases
{

    internal class casGenrateStudentMarksReportForSelectedSubject : ICaseDeleteFakeData
    {
        public int SubjectID { get; private set; }
        public int ClassID { get; private set; }

        public void GenrateFakeData(int NumberOfStudents = 5)
        {
            for (int i = 0; i < NumberOfStudents; i++)
            {
                clsPerson newPerson = new clsPerson();

                newPerson.FirstName = "John";
                newPerson.LastName = "Doe";
                newPerson.DateOfBirth = new DateTime(2000, 1, 1);
                newPerson.Address = "123 Main St, Springfield, USA";

                if (!newPerson.Save())
                    throw new Exception(newPerson.ErrorMessages.FirstOrDefault());

                clsContainer.FakePersons.Add(newPerson);

                // Create a new student associated with the person
                clsStudent newStudent = new clsStudent();
                newStudent.PersonID = newPerson.ID;
                newStudent.EnrollmentNumber = "ENT-" + Guid.NewGuid().ToString("N").Substring(0,12);
                newStudent.CurrentGradeLevel = 1;

                if (!newStudent.Save())
                    throw new Exception(newStudent.ErrorMessages.FirstOrDefault());

                clsContainer.FakeStudents.Add(newStudent);
            }

            // Create a subject
            clsSubject newSubject = new clsSubject();

            newSubject.SubjectName = "Mathematics";
            newSubject.SubjectCode = "MATH" + Guid.NewGuid().ToString("N").Substring(0,3);
            newSubject.Department = "Mathematics Department";
            newSubject.Description = "Introduction to Mathematics";

            if (!newSubject.Save())
                throw new Exception(newSubject.ErrorMessages.FirstOrDefault());

            clsContainer.FakeSubjects.Add(newSubject);

            // Create Class

            clsSchoolClass newClass = new clsSchoolClass();

            newClass.ClassName = "Math 101";
            newClass.GradeLevel = 1;
            newClass.AcademicYear = "2023-2024";

            if (!newClass.Save())
                throw new Exception(newClass.ErrorMessages.FirstOrDefault());

            clsContainer.FakeClasses.Add(newClass);

            // Enroll students in the class


            foreach (var student in clsContainer.FakeStudents)
            {
                clsStudentClass classStudents = new clsStudentClass();
                classStudents.StudentID = student.ID;
                classStudents.ClassID = newClass.ID;

                if (!classStudents.Save())
                    throw new Exception(classStudents.ErrorMessages.FirstOrDefault());
                clsContainer.FakeStudentClass.Add(classStudents);
            }

            // Create a Teacher

            clsPerson teacherPerson = new clsPerson();
            teacherPerson.FirstName = "Jane";
            teacherPerson.LastName = "Smith";
            teacherPerson.DateOfBirth = new DateTime(1985, 5, 15);
            teacherPerson.Address = "456 Elm St, Springfield, USA";
            teacherPerson.Email = "Jane@gmail.com";

            if(!teacherPerson.Save())
                throw new Exception(teacherPerson.ErrorMessages.FirstOrDefault());

            clsContainer.FakePersons.Add(teacherPerson);

            clsStaff newStaff = new clsStaff();

            newStaff.PersonID = teacherPerson.ID;
            newStaff.Department = "Mathematics Department";
            newStaff.StaffNumber = "STF-" + new Random().Next(1000, 9999).ToString();

            if (!newStaff.Save())
                throw new Exception(newStaff.ErrorMessages.FirstOrDefault());

            clsContainer.FakeStaffs.Add(newStaff);

            clsTeacher newTeacher = new clsTeacher();

            newTeacher.StaffID = newStaff.ID;
            newTeacher.SubjectSpecialization = "Mathematics";

            if (!newTeacher.Save())
                throw new Exception(newTeacher.ErrorMessages.FirstOrDefault());

            clsContainer.FakeTeachers.Add(newTeacher);

            // Assign subject to the class

            clsClassSubject classSubject = new clsClassSubject();

            classSubject.SubjectID = newSubject.ID;
            classSubject.ClassID = newClass.ID;
            classSubject.ScheduleDay = "Monday";
            classSubject.StartTime = new TimeSpan(NumberOfStudents % 24, 0, 0); // Just a simple way to vary start time
            classSubject.EndTime = new TimeSpan(Convert.ToInt32(TimeSpan.FromHours(1).TotalHours + NumberOfStudents % 24), 0, 0); // 1 hour duration
            classSubject.TeacherID = newTeacher.ID;

            if(!classSubject.Save())
                throw new Exception(classSubject.ErrorMessages.FirstOrDefault());

            clsContainer.FakeClassSubjects.Add(classSubject);

            // Generate marks for each student in the subject

            foreach(var student in clsContainer.FakeStudents)
            {
                var Types = clsGradesRoles
                    .GradeTypeRoles
                    .Select(
                        t => new 
                        { 
                            TypeName = t.Key.ToString(), 
                            t.Value.Weight, 
                            t.Value.MaxScore 
                        }
                    )
                    .ToList();
                foreach(var type in Types)
                {
                    clsGrade newMark = new clsGrade();

                    newMark.StudentID = student.ID;
                    newMark.ClassSubjectID = classSubject.ID;
                    newMark.GradeType = type.TypeName;
                    newMark.GradeDate = DateTime.Today.AddDays(new Random().Next(-1000, -10));
                    newMark.Score = new Random().Next(0, type.MaxScore + 1); // Random score between 0 and MaxScore
                    newMark.MaxScore = type.MaxScore;
                    newMark.Weight = type.Weight;

                    if(!newMark.Save())
                        throw new Exception(newMark.ErrorMessages.FirstOrDefault());

                    clsContainer.FakeMarks.Add(newMark);
                }
            }

            this.ClassID = newClass.ID;
            this.SubjectID = newSubject.ID;
        }

        public void DeleteFakeData()
        {
            // The order of deletion is reversed to respect foreign key constraints.
            // Last created is deleted first, and first created is deleted last.

            // 1. Delete all grades (marks)
            foreach (var mark in clsContainer.FakeMarks)
            {
                if (!clsGrade.Delete(mark.ID))
                    throw new Exception(mark.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakeMarks.Clear();

            // 2. Delete all class subjects
            foreach (var classSubject in clsContainer.FakeClassSubjects)
            {
                if (!clsClassSubject.Delete(classSubject.ID))
                    throw new Exception(classSubject.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakeClassSubjects.Clear();

            // 3. Delete all teachers
            foreach (var teacher in clsContainer.FakeTeachers)
            {
                if (!clsTeacher.Delete(teacher.ID))
                    throw new Exception(teacher.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakeTeachers.Clear();

            // 4. Delete all staff
            foreach (var staff in clsContainer.FakeStaffs)
            {
                if (!clsStaff.Delete(staff.ID))
                    throw new Exception(staff.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakeStaffs.Clear();

            // 5. Delete all student-class enrollments
            foreach (var studentClass in clsContainer.FakeStudentClass)
            {
                if (!clsStudentClass.Delete(studentClass.ID))
                    throw new Exception(studentClass.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakeStudentClass.Clear();

            // 6. Delete all classes
            foreach (var cls in clsContainer.FakeClasses)
            {
                if (!clsSchoolClass.Delete(cls.ID))
                    throw new Exception(cls.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakeClasses.Clear();

            // 7. Delete all subjects
            foreach (var subject in clsContainer.FakeSubjects)
            {
                if (!clsSubject.Delete(subject.ID))
                    throw new Exception(subject.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakeSubjects.Clear();

            // 8. Delete all students
            foreach (var student in clsContainer.FakeStudents)
            {
                if (!clsStudent.Delete(student.ID))
                    throw new Exception(student.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakeStudents.Clear();

            // 9. Delete all persons (students and teacher)
            foreach (var person in clsContainer.FakePersons)
            {
                if (!clsPerson.Delete(person.ID))
                    throw new Exception(person.ErrorMessages.FirstOrDefault());
            }
            clsContainer.FakePersons.Clear();
        }

        public casGenrateStudentMarksReportForSelectedSubject()
        {
            this.GenrateFakeData();
        }
    }
}
