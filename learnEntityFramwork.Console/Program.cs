using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudentManagementSystem.BusinessLogic;
using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.DataAccess.Services.ProcedureServices;
using StudentManagementSystem.DataAccess.StoredProcedures;

namespace learnEntityFramwork.ConsoleApp
{
    internal class Program
    {
        static void TestClsUser()
        {
            clsUser User = new clsUser();

            User.Username = "testuser" + Guid.NewGuid().ToString("N").Substring(0, 5);
            User.Password = "Password";
            User.Role = "Admin";
            User.IsActive = true;

            if (User.Save())
            {
                Console.WriteLine("User added successfully with ID: " + User.ID);
                clsUser GetUser = clsUser.Find(User.ID);

                if(GetUser == null)
                {
                    Console.WriteLine("The User is Not Find: " + string.Join(",\n", GetUser.ErrorMessages));
                }

                Console.WriteLine("User Password: " + GetUser.Password);

                GetUser.Password += "123";

                if(GetUser.Save())
                {
                    Console.WriteLine("Update SuccessFully new Password is: " + clsUser.Find(GetUser.ID).Password);

                    int UserCount = clsUser.GetAllUser().Count;

                    Console.WriteLine("Users Count: " + UserCount);

                    clsUser.Delete(GetUser.ID);

                    Console.WriteLine("Users Count: " + clsUser.GetAllUser().Count);
                }
                else
                {
                    Console.WriteLine("Update Faild Error: ", string.Join(",\n", GetUser.ErrorMessages));
                }
            }
            else
            {
                Console.WriteLine("Error adding user: " + string.Join(",\n", User.ErrorMessages));
            }
        }

        static void TestclsPerson()
        {
            clsPerson Person = new clsPerson();

            //public int UserID { get; set; }
            //public string FirstName { get; set; }
            //public string LastName { get; set; }
            //public DateTime DateOfBirth { get; set; }
            //public string Gender { get; set; }
            //public string Email { get; set; }
            //public string PhoneNumber { get; set; }
            //public string Address { get; set; }

            Person.UserID = 1;
            Person.FirstName = "TestName";
            Person.LastName = "TestName";
            Person.DateOfBirth = DateTime.Today.AddYears(-9);
            Person.Gender = "Unkonwed";
            Person.Email = "Email@Internet.net";
            Person.PhoneNumber = "1234567890";
            Person.Address = "City Way 111";
            Person.Photo = null;


            if (Person.Save())
            {
                Console.WriteLine("Person added successfully with ID: " + Person.ID);
                clsPerson GetPerson = clsPerson.Find(Person.ID);

                if (GetPerson == null)
                {
                    Console.WriteLine("The Person is Not Find: " + string.Join(",\n", GetPerson.ErrorMessages));
                }

                Console.WriteLine("Person Password: " + GetPerson.Address);

                GetPerson.Address += "123";

                if (GetPerson.Save())
                {
                    Console.WriteLine("Update SuccessFully new Password is: " + clsPerson.Find(GetPerson.ID).Address);

                    int PersonCount = clsPerson.GetAllPeople().Count;

                    Console.WriteLine("Persons Count: " + PersonCount);

                    clsPerson.Delete(GetPerson.ID);

                    Console.WriteLine("Persons Count: " + clsPerson.GetAllPeople().Count);
                }
                else
                {
                    Console.WriteLine("Update Faild Error: ", string.Join(",\n", GetPerson.ErrorMessages));
                }
            }
            else
            {
                Console.WriteLine("Error adding user: " + string.Join(",\n", Person.ErrorMessages));
            }
        }

        static void TestclsStudent()
        {
            clsStudent Student = new clsStudent();

            //public int PersonID { get; set; }
            //public string EnrollmentNumber { get; set; }
            //public DateTime EnrollmentDate { get; set; }
            //public int ParentID { get; set; }
            //public int CurrentGradeLevel { get; set; }

            Student.PersonID = 1;
            Student.EnrollmentNumber = "Number" + Guid.NewGuid().ToString("N").Substring(0,5);
            Student.EnrollmentDate = DateTime.Today.AddYears(-3);
            Student.ParentID = clsPerson.GetAllPeople()[2].ID;
            Student.CurrentGradeLevel = 2;


            if (Student.Save())
            {
                Console.WriteLine("Student added successfully with ID: " + Student.ID);
                clsStudent GetStudent = clsStudent.Find(Student.ID);

                if (GetStudent == null)
                {
                    Console.WriteLine("The Student is Not Find: " + string.Join(",\n", GetStudent.ErrorMessages));
                }

                Console.WriteLine("Student Password: " + GetStudent.CurrentGradeLevel);

                GetStudent.CurrentGradeLevel = 5;

                if (GetStudent.Save())
                {
                    Console.WriteLine("Update SuccessFully new Password is: " + clsStudent.Find(GetStudent.ID).CurrentGradeLevel);

                    int StudentCount = clsStudent.GetAllStudent().Count;

                    Console.WriteLine("Students Count: " + StudentCount);

                    clsStudent.Delete(GetStudent.ID);

                    Console.WriteLine("Students Count: " + clsStudent.GetAllStudent().Count);
                }
                else
                {
                    Console.WriteLine("Update Faild Error: ", string.Join(",\n", GetStudent.ErrorMessages));
                }
            }
            else
            {
                Console.WriteLine("Error adding user: " + string.Join(",\n", Student.ErrorMessages));
            }
        }

        static void TestclsStaff()
        {
            clsStaff Staff = new clsStaff();

            //public int PersonID { get; set; }
            //public string StaffNumber { get; set; }
            //public string Position { get; set; }
            //public DateTime HireDate { get; set; }
            //public string Department { get; set; }
            //public decimal Salary { get; set; }

            Staff.PersonID = 1;
            Staff.StaffNumber = "ENF" + Guid.NewGuid().ToString("N").Substring(0,5);
            Staff.Position = "Teacher";
            Staff.HireDate = DateTime.Today.AddDays(-90);
            Staff.Department = "IT";
            Staff.Salary = 10000;

            if (Staff.Save())
            {
                Console.WriteLine("Staff added successfully with ID: " + Staff.ID);
                clsStaff GetStaff = clsStaff.Find(Staff.ID);

                if (GetStaff == null)
                {
                    Console.WriteLine("The Staff is Not Find: " + string.Join(",\n", GetStaff.ErrorMessages));
                }

                Console.WriteLine("Staff Password: " + GetStaff.Department);

                GetStaff.Department = "Health";

                if (GetStaff.Save())
                {
                    Console.WriteLine("Update SuccessFully new Password is: " + clsStaff.Find(GetStaff.ID).Department);

                    int StaffCount = clsStaff.GetAllStaff().Count;

                    Console.WriteLine("Staffs Count: " + StaffCount);

                    clsStaff.Delete(GetStaff.ID);

                    Console.WriteLine("Staffs Count: " + clsStaff.GetAllStaff().Count);
                }
                else
                {
                    Console.WriteLine("Update Faild Error: ", string.Join(",\n", GetStaff.ErrorMessages));
                }
            }
            else
            {
                Console.WriteLine("Error adding user: " + string.Join(",\n", Staff.ErrorMessages));
            }
        }

        static void TestclsTeacher()
        {
            clsTeacher Teacher = new clsTeacher();

            //public int StaffID { get; set; }
            //public string SubjectSpecialization { get; set; }

            Teacher.StaffID = 1;
            Teacher.SubjectSpecialization = "SJS" + Guid.NewGuid().ToString("N").Substring(0,5);

            if (Teacher.Save())
            {
                Console.WriteLine("Teacher added successfully with ID: " + Teacher.ID);
                clsTeacher GetTeacher = clsTeacher.Find(Teacher.ID);

                if (GetTeacher == null)
                {
                    Console.WriteLine("The Teacher is Not Find: " + string.Join(",\n", GetTeacher.ErrorMessages));
                }

                Console.WriteLine("Teacher Password: " + GetTeacher.SubjectSpecialization);

                GetTeacher.SubjectSpecialization += "Health";

                if (GetTeacher.Save())
                {
                    Console.WriteLine("Update SuccessFully new Password is: " + clsTeacher.Find(GetTeacher.ID).SubjectSpecialization);

                    int TeacherCount = clsTeacher.GetAllTeacher().Count;

                    Console.WriteLine("Teachers Count: " + TeacherCount);

                    clsTeacher.Delete(GetTeacher.ID);

                    Console.WriteLine("Teachers Count: " + clsTeacher.GetAllTeacher().Count);
                }
                else
                {
                    Console.WriteLine("Update Faild Error: ", string.Join(",\n", GetTeacher.ErrorMessages));
                }
            }
            else
            {
                Console.WriteLine("Error adding user: " + string.Join(",\n", Teacher.ErrorMessages));
            }
        }

        static void TestActvitValidation()
        {
            // بيانات صحيحة
            //ActvitsValidationTest.TestValidationOfStudentClass(5, 3, DateTime.Now);
            //Console.WriteLine("\n\n\n\n");
            //// بيانات خاطئة: ID سالب، وتاريخ في المستقبل
            //ActvitsValidationTest.TestValidationOfStudentClass(-1, 0, DateTime.Now.AddDays(2));
            //Console.WriteLine("\n\n\n\n");
            //// ✅ بيانات صحيحة
            //ActvitsValidationTest.TestValidationOfNotification(
            //    senderId: 1,
            //    receiverId: 2,
            //    title: "Important Update",
            //    message: "Please check your email for the latest announcement.",
            //    sentDate: DateTime.Now.AddMinutes(-10)
            //);
            //Console.WriteLine("\n\n\n\n");
            //// ❌ بيانات خاطئة
            //ActvitsValidationTest.TestValidationOfNotification(
            //    senderId: 0,
            //    receiverId: -5,
            //    title: "", // فارغ
            //    message: new string('x', 600), // أطول من 500 حرف
            //    sentDate: DateTime.Now.AddDays(1) // تاريخ في المستقبل
            //);
            //Console.WriteLine("\n\n\n\n");
            //// ✅ بيانات صحيحة
            //ActvitsValidationTest.TestValidationOfGrade(
            //    studentId: 1,
            //    classSubjectId: 2,
            //    gradeType: "Exam",
            //    gradeDate: DateTime.Now.AddDays(-3),
            //    score: 85.5m,
            //    maxScore: 100m,
            //    weight: 0.3m,
            //    comments: "Good performance."
            //);
            //Console.WriteLine("\n\n\n\n");
            //// ❌ بيانات خاطئة
            //ActvitsValidationTest.TestValidationOfGrade(
            //    studentId: -10,
            //    classSubjectId: 0,
            //    gradeType: new string('X', 25), // أكثر من 20 حرف
            //    gradeDate: DateTime.Now.AddDays(2), // مستقبل
            //    score: 110m,
            //    maxScore: 100m,
            //    weight: -5,
            //    comments: new string('A', 300) // أكثر من 200
            //);
            //Console.WriteLine("\n\n\n\n");
            // ✅ بيانات صحيحة
            //ActvitsValidationTest.TestValidationOfClassSubject(
            //    classId: 3,
            //    subjectId: 6,
            //    teacherId: 3,
            //    scheduleDay: "Monday",
            //    startTime: new TimeSpan(8, 0, 0),
            //    endTime: new TimeSpan(9, 30, 0),
            //    roomNumber: "A101"
            //);
            //Console.WriteLine("\n\n\n\n");
            //// ❌ بيانات خاطئة
            //ActvitsValidationTest.TestValidationOfClassSubject(
            //    classId: -1,
            //    subjectId: 0,
            //    teacherId: -5,
            //    scheduleDay: "VeryLongDayName",
            //    startTime: new TimeSpan(10, 0, 0),
            //    endTime: new TimeSpan(9, 0, 0),
            //    roomNumber: new string('X', 25) // أكثر من 20 حرف
            //);
            //Console.WriteLine("\n\n\n\n");
            //// ✅ بيانات صحيحة
            //ActvitsValidationTest.TestValidationOfAttendance(
            //    studentId: 1,
            //    classSubjectId: 2,
            //    date: DateTime.Today,
            //    status: "Present",
            //    notes: "On time"
            //);
            //Console.WriteLine("\n\n\n\n");
            //// ❌ بيانات خاطئة
            //ActvitsValidationTest.TestValidationOfAttendance(
            //    studentId: -5,
            //    classSubjectId: 0,
            //    date: DateTime.Now.AddDays(3), // مستقبل
            //    status: new string('A', 25),   // أكثر من 20 حرف
            //    notes: new string('X', 300)    // أكثر من 200 حرف
            //);
        }

        static void TestActvitsMunpultion()
        {
            //ActvitsManpultionTest.TestAttendanceService(
            //    studentId: 1,
            //    classSubjectId: 2,
            //    date: DateTime.Now.Date,
            //    status: "Absent",
            //    notes: "Was sick"
            //);
            //Console.WriteLine("\n\n\n");
            ActvitsManpultionTest.TestClassSubjectService(
                classId: 1,
                subjectId: 1,
                teacherId: 1,
                scheduleDay: "Monday",
                startTime: new TimeSpan(8, 30, 0),
                endTime: new TimeSpan(10, 0, 0),
                roomNumber: "A101"
            );
            //Console.WriteLine("\n\n\n");
            //ActvitsManpultionTest.TestGradeService(
            //    studentId: 1,            // تأكد أن هذا الطالب موجود
            //    classSubjectId: 1,       // تأكد أن هذا الـ ClassSubject موجود
            //    gradeType: "Midterm",
            //    gradeDate: DateTime.Now.AddDays(-10),
            //    score: 85.5m,
            //    maxScore: 100m,
            //    weight: 0.3m,
            //    comments: "Good performance"
            //);
            //Console.WriteLine("\n\n\n");
            //ActvitsManpultionTest.TestNotificationService(
            //    senderId: 1,      // تأكد أن المستخدم صاحب هذا ID موجود
            //    receiverId: 2,    // تأكد أن المستقبل موجود أيضًا
            //    title: "New Assignment",
            //    message: "You have a new assignment due next week."
            //);
            //ActvitsManpultionTest.TestStudentClassService(
            //    studentId: 1,         // تأكد أن هذا الطالب موجود مسبقًا
            //    classId: 3,           // تأكد أن هذا الصف موجود مسبقًا
            //    enrollmentDate: DateTime.Now
            //);
            //Console.WriteLine("\n\n\n");
        }

        class Employment
        {
            public string Name { get; set; }
            public string Posistion { get; set; }
            public int Salary { get; set; }
            public string Email { get; set; }

            public Employment(string name, string posistion, int salary, string email) 
            {
                this.Name = name;
                this.Posistion = posistion;
                this.Salary = salary;
                this.Email = email;
            }
        }

        static void Main(string[] args)
        {
            //SimplePdfCreator.CreateSimplePdf("Test");

            List<Employment> List = new List<Employment>
            {
                new Employment("Ahmad", "Teacher", 1000, "Email@mail.com"),
                new Employment("Hamda", "Tester", 1000, "Email@mail.com"),
                new Employment("Faadomo", "Clean Lady", 1000, "Email@mail.com"),
                new Employment("Sayenb", "Salary", 1000, "Email@mail.com")
            };

            PdfExporter<Employment> pdfExporter = new PdfExporter<Employment>();

            pdfExporter.SetHeader(new string[] { "Name", "Posistion", "Email" , "Salary" });
            pdfExporter.AddData(List);

            pdfExporter.SaveToFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestTable1.pdf"));
        }
    }
}
