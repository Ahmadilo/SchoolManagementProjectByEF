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
using StudentSystem.UnitTesting.DataGenrate;

namespace StudentSystem.UnitTesting.Cases
{

    internal class casGenrateStudentMarksReportForSelectedSubject : ICaseDeleteFakeData
    {
        public int SubjectID { get; private set; }
        public int ClassID { get; private set; }

        private void GenrateFakeData(int NumberOfStudents = 5)
        {
            for (int i = 0; i < NumberOfStudents; i++)
            {
                // Create a new student associated with the person
                clsDataGenrate.GenrateStudent();
            }

            // Create a subject
            clsSubject newSubject = clsDataGenrate.GenrateSubject();

            // Create Class

            clsSchoolClass newClass = clsDataGenrate.GenrateClass();

            // Enroll students in the class


            foreach (var student in clsContainer.FakeStudents)
            {
                clsStudentClass classStudents = clsDataGenrate.GenrateStudentClass(
                    student.ID,
                    newClass.ID
                );
            }

            // Assign subject to the class

            clsClassSubject classSubject = clsDataGenrate.GenrateClassSubject(SubjectID: newSubject.ID, ClassID: newClass.ID);

            // Generate marks for each student in the subject

            foreach(var student in clsContainer.FakeStudents)
            {
                var Types = clsDataGenrate.TypesMarks;
                foreach(var type in Types)
                {
                    clsGrade newMark = clsDataGenrate.GenrateGrade
                        (
                            StudentID: student.ID,
                            ClassSubjectID: classSubject.ID,
                            GradeType: type.TypeName,
                            MaxScore: type.MaxScore,
                            Score: new Random().Next(0, type.MaxScore + 1), // Random score between 0 and MaxScore
                            Weight: type.Weight,
                            Date: DateTime.Today.AddDays(new Random().Next(-1000, -10)).ToString()
                        );
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
