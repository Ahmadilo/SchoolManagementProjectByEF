using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic
{
    public class Class1
    {
        public static void AddUserExample(string Uname = "123")
        {
            UserService userService = new UserService();
            User newUser = new User
            {
                Username = "testuser" + Uname,
                Password = "password123",
                Role = "Student",
                LastLogin = DateTime.Now,
                IsActive = true
            };

            int userId = userService.AddUser(newUser);
            Console.WriteLine($"New user added with ID: {userId}");
        }

        public static void GetUserByIdExample(int userId)
        {
            UserService userService = new UserService();
            User user = userService.GetUserById(userId);

            if (user != null)
            {
                Console.WriteLine($"User found: {user.Username}, Role: {user.Role}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public static void UpdateUserExample()
        {
            UserService userService = new UserService();

            User updateUser = userService.GetUserById(1);

            updateUser.Username = "admin";

            bool Result = userService.UpdateUser(updateUser);

            if (Result)
            {
                Console.WriteLine("User updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update user.");
            }
        }

        public static void DeleteUserExample(int ID)
        {
            UserService userService = new UserService();

            bool Result = userService.DeleteUser(ID);

            if (Result)
            {
                Console.WriteLine("Susseccfully");
            }
            else
            {
                Console.WriteLine("Failed to delete user.");
            }
        }

        public static void GetAllUserExample()
        {
            UserService userService = new UserService();

            List<User> users = userService.GetAllUsers();

            Console.WriteLine("User Count is " + users.Count);
        }

        public static void AddPersonExample()
        {
            PeopleService people = new PeopleService();

            Person person = new Person();

            person.UserID = 1;
            person.FirstName = "FristName";
            person.LastName = "LastName";
            person.DateOfBirth = DateTime.Today.AddYears(-18);
            person.Gender = "Male";
            person.Email = "Email";
            person.Phone = "1234567890";
            person.Address = "Address";
            person.Photo = null; // Assuming no photo is provided

            person.PersonID = people.AddPerson(person);

            if (person.PersonID != -1)
                Console.WriteLine("Done");
            else
                Console.WriteLine("Not Done!");
        }

        public static void GetPersonExample(int ID)
        {
            PeopleService peopleService = new PeopleService();

            Person person = peopleService.GetPersonById(ID);

            if (person != null)
            {
                Console.WriteLine($"Person found: {person.FirstName} {person.LastName}, Email: {person.Email}");
            }
            else
            {
                Console.WriteLine("Person not found.");
            }
        }

        public static void UpdatePersonExample(int ID)
        {
            PeopleService peopleService = new PeopleService();

            Person person = peopleService.GetPersonById(ID);

            person.FirstName += "Updated";

            if (peopleService.UpdatePerson(person))
            {
                person = peopleService.GetPersonById(ID);
                Console.WriteLine("The First Name is " + person.FirstName);
            }
            else
            {
                Console.WriteLine("Not Done!!!");
            }
        }

        public static void DeletePersonExample(int ID)
        {
            PeopleService peopleService = new PeopleService();

            bool result = peopleService.DeletePerson(ID);

            if (result)
            {
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Not Done.!!!");
            }
        }

        public static void GetAllPeopleExample()
        {
            PeopleService peopleService = new PeopleService();

            List<Person> people = peopleService.GetAllPeople();

            Console.WriteLine("The People Counter is " + people.Count);
        }

        public static void AddStudentExample()
        {
            StudentService studentService = new StudentService();

            Student newStudent = new Student
            {
                PersonID = 1, // Assuming the person with ID 1 exists
                ParentID = 2, // Assuming the parent with ID 2 exists
                CurrentGradeLevel = 100,
                EnrollmentNumber = "ENR" + Guid.NewGuid().ToString("N").Substring(0, 8),
                EnrollmentDate = DateTime.Now
            };



            newStudent.PersonID = studentService.AddStudent(newStudent);

            if (newStudent.PersonID != -1)
            {
                Console.WriteLine("Student added successfully with ID: " + newStudent.PersonID);
            }
            else
            {
                Console.WriteLine("Failed to add student.");
            }
        }

        public static void GetStudentExample()
        {
            StudentService studentService = new StudentService();

            Student student = studentService.GetStudentById(1); // Assuming we want to get the student with ID 1

            if (student != null)
            {
                Console.WriteLine($"Student found: {student.Person.FirstName} {student.Person.LastName}, Enrollment Number: {student.EnrollmentNumber}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public static void UpdateStudentExample()
        {
            StudentService studentService = new StudentService();

            Student student = studentService.GetStudentById(1); // Assuming we want to update the student with ID 1

            if (student != null)
            {
                student.EnrollmentNumber = "EN12345"; // Update the enrollment number
                student.CurrentGradeLevel = 200; // Update the grade level

                bool result = studentService.UpdateStudent(student);

                if (result)
                {
                    student = studentService.GetStudentById(1); // Fetch the updated student
                    Console.WriteLine("Student updated successfully. Grad: " + student.CurrentGradeLevel);
                }
                else
                {
                    Console.WriteLine("Failed to update student.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public static void DeleteStudentExample(int id)
        {
            StudentService studentService = new StudentService();

            bool result = studentService.DeleteStudent(id);

            if (result)
            {
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete student.");
            }
        }

        public static void GetAllStudentsExample()
        {
            StudentService studentService = new StudentService();

            List<Student> students = studentService.GetAllStudents();

            Console.WriteLine("Student Counter is: " + students.Count);
        }

        public static void AddStaffExample()
        {
            StaffService staffService = new StaffService();

            Staff newStaff = new Staff
            {
                PersonID = 1, // تأكد أن الشخص بهذا الرقم موجود
                StaffNumber = "STF" + Guid.NewGuid().ToString("N").Substring(0, 8),
                HireDate = DateTime.Today,
                Position = "Math Teacher",
                Department = "Mathematics",
                Salary = 3500.00m
            };

            newStaff.StaffID = staffService.AddStaff(newStaff);

            if (newStaff.StaffID != -1)
            {
                Console.WriteLine("Staff added successfully with ID: " + newStaff.StaffID);
            }
            else
            {
                Console.WriteLine("Failed to add staff.");
            }
        }

        public static void GetStaffExample()
        {
            StaffService staffService = new StaffService();

            Staff staff = staffService.GetStaffById(1); // عدل الرقم حسب الحاجة

            if (staff != null)
            {
                Console.WriteLine($"Staff found: {staff.Person.FirstName} {staff.Person.LastName}, Position: {staff.Position}");
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }
        }

        public static void UpdateStaffExample()
        {
            StaffService staffService = new StaffService();

            Staff staff = staffService.GetStaffById(1); // عدل الرقم حسب الحاجة

            if (staff != null)
            {
                staff.Position = "Senior Math Teacher";
                staff.Salary = 4200.00m;

                bool result = staffService.UpdateStaff(staff);

                if (result)
                {
                    staff = staffService.GetStaffById(staff.StaffID);
                    Console.WriteLine("Staff updated successfully. New position: " + staff.Position);
                }
                else
                {
                    Console.WriteLine("Failed to update staff.");
                }
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }
        }

        public static void DeleteStaffExample(int id)
        {
            StaffService staffService = new StaffService();

            bool result = staffService.DeleteStaff(id);

            if (result)
            {
                Console.WriteLine("Staff deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete staff.");
            }
        }

        public static void GetAllStaffExample()
        {
            StaffService staffService = new StaffService();

            List<Staff> staffList = staffService.GetAllStaffs();

            Console.WriteLine("Staff Counter is: " + staffList.Count);
        }

        public static void AddTeacherExample()
        {
            TeacherService teacherService = new TeacherService();

            Teacher newTeacher = new Teacher
            {
                StaffID = 1, // تأكد أن الموظف بهذا الرقم موجود
                SubjectSpecialization = "Physics"
            };

            newTeacher.TeacherID = teacherService.AddTeacher(newTeacher);

            if (newTeacher.TeacherID != -1)
            {
                Console.WriteLine("Teacher added successfully with ID: " + newTeacher.TeacherID);
            }
            else
            {
                Console.WriteLine("Failed to add teacher.");
            }
        }

        public static void GetTeacherExample()
        {
            TeacherService teacherService = new TeacherService();

            Teacher teacher = teacherService.GetTeacherById(1); // عدل الرقم حسب الحاجة

            if (teacher != null)
            {
                Console.WriteLine($"Teacher found: StaffID: {teacher.StaffID}, Subject: {teacher.SubjectSpecialization}");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }

        public static void UpdateTeacherExample()
        {
            TeacherService teacherService = new TeacherService();

            Teacher teacher = teacherService.GetTeacherById(1); // عدل الرقم حسب الحاجة

            if (teacher != null)
            {
                teacher.SubjectSpecialization = "Advanced Physics";

                bool result = teacherService.UpdateTeacher(teacher);

                if (result)
                {
                    teacher = teacherService.GetTeacherById(teacher.TeacherID);
                    Console.WriteLine("Teacher updated successfully. New subject: " + teacher.SubjectSpecialization);
                }
                else
                {
                    Console.WriteLine("Failed to update teacher.");
                }
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }

        public static void DeleteTeacherExample(int id)
        {
            TeacherService teacherService = new TeacherService();

            bool result = teacherService.DeleteTeacher(id);

            if (result)
            {
                Console.WriteLine("Teacher deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete teacher.");
            }
        }

        public static void GetAllTeachersExample()
        {
            TeacherService teacherService = new TeacherService();

            List<Teacher> teacherList = teacherService.GetAllTeachers();

            Console.WriteLine("Teacher Counter is: " + teacherList.Count);
        }

        public static void AddPersonWithVaidtionExample()
        {
            PeopleService peopleService = new PeopleService();

            Person person = new Person();

            person.UserID = 1; // Assuming the user with ID 1 exists
            person.FirstName = "John";
            person.LastName = "Doe";
            person.DateOfBirth = DateTime.Today.AddYears(-18);
            person.Gender = "Male";
            person.Email = "Email@gmail.com";
            person.Phone = "1234567890";
            person.Address = "123 Main St, City, Country";
            person.Photo = null;

            person.PersonID = peopleService.AddPerson(person);

            if (person.PersonID != -1)
            {
                Console.WriteLine("Person added successfully with ID: " + person.PersonID);

                Console.WriteLine("Validating person data is: ");
                List<string> validationErrors = PeopleService.PersonValidationBasic(person);
                for (int i = 0; i < validationErrors.Count; i++)
                    Console.WriteLine($"{i + 1}. {validationErrors[i]}");
            }
            else
            {
                Console.WriteLine("Failed to add person.");
            }
        }

        public static void AddUserWithVaidtionExample()
        {
            UserService userService = new UserService();

            User user = new User
            {
                Username = "newuser" + Guid.NewGuid().ToString("N").Substring(0, 8),
                Password = "password123",
                Role = "Student",
                LastLogin = DateTime.Now,
                IsActive = true
            };

            user.UserID = userService.AddUser(user);

            if (user.UserID != -1)
            {
                Console.WriteLine("User added successfully with ID: " + user.UserID);

                Console.WriteLine("Validating user data is: ");
                List<string> validationErrors = UserService.UserValidationBasic(user);
                for (int i = 0; i < validationErrors.Count; i++)
                    Console.WriteLine($"{i + 1}. {validationErrors[i]}");
            }
            else
            {
                Console.WriteLine("Failed to add user.");
            }
        }

        public static void AddStudentWithValidationExample()
        {
            StudentService studentService = new StudentService();

            // نفترض أن PersonID صالح وموجود مسبقًا في الجدول
            int validPersonId = 1;
            int validParentId = 1; // يمكن تركه فارغًا حسب الجدول

            Student student = new Student
            {
                PersonID = validPersonId,
                EnrollmentNumber = "ENR" + Guid.NewGuid().ToString("N").Substring(0, 5),
                EnrollmentDate = DateTime.Today,
                ParentID = validParentId,
                CurrentGradeLevel = 5
            };

            student.StudentID = studentService.AddStudent(student);

            if (student.StudentID != -1)
            {
                Console.WriteLine("Student added successfully with ID: " + student.StudentID);
                Console.WriteLine("Validating student data...");

                List<string> validationErrors = StudentService.StudentValidationBasic(student);

                if (validationErrors.Count == 0)
                {
                    Console.WriteLine("✔ No validation errors. Validation logic is consistent with database constraints.");
                }
                else
                {
                    Console.WriteLine("⚠ Validation errors found **after** database insert (possible logic inconsistency):");
                    for (int i = 0; i < validationErrors.Count; i++)
                        Console.WriteLine($"{i + 1}. {validationErrors[i]}");
                }
            }
            else
            {
                Console.WriteLine("❌ Failed to add student to the database.");
            }
        }

        public static void AddStaffWithValidationExample()
        {
            StaffService staffService = new StaffService();

            // نفترض أن PersonID صالح وموجود في قاعدة البيانات
            int validPersonId = 1;

            Staff staff = new Staff
            {
                PersonID = validPersonId,
                StaffNumber = "STF" + Guid.NewGuid().ToString("N").Substring(0, 5),
                HireDate = DateTime.Today,
                Position = "Teacher",
                Department = "Science",
                Salary = 4500.00m
            };

            staff.StaffID = staffService.AddStaff(staff);

            if (staff.StaffID != -1)
            {
                Console.WriteLine("Staff added successfully with ID: " + staff.StaffID);
                Console.WriteLine("Validating staff data...");

                List<string> validationErrors = StaffService.StaffValidationBasic(staff);

                if (validationErrors.Count == 0)
                {
                    Console.WriteLine("✔ No validation errors. Validation logic is consistent with database constraints.");
                }
                else
                {
                    Console.WriteLine("⚠ Validation errors found **after** database insert (possible logic inconsistency):");
                    for (int i = 0; i < validationErrors.Count; i++)
                        Console.WriteLine($"{i + 1}. {validationErrors[i]}");
                }
            }
            else
            {
                Console.WriteLine("❌ Failed to add staff to the database.");
            }
        }

        public static void AddTeacherWithValidationExample()
        {
            TeacherService teacherService = new TeacherService();

            // نفترض أن StaffID صالح وموجود مسبقًا في جدول Staff
            int validStaffId = 1;

            Teacher teacher = new Teacher
            {
                StaffID = validStaffId,
                SubjectSpecialization = "Mathematics"
            };

            // استدعاء دالة لإضافة المدرّس (تأكد أنك أنشأت AddTeacher في TeacherService)
            teacher.TeacherID = teacherService.AddTeacher(teacher);

            if (teacher.TeacherID != -1)
            {
                Console.WriteLine("Teacher added successfully with ID: " + teacher.TeacherID);
                Console.WriteLine("Validating teacher data...");

                List<string> validationErrors = TeacherService.TeacherValidationBasic(teacher);

                if (validationErrors.Count == 0)
                {
                    Console.WriteLine("✔ No validation errors. Validation logic is consistent with database constraints.");
                }
                else
                {
                    Console.WriteLine("⚠ Validation errors found **after** database insert (possible logic inconsistency):");
                    for (int i = 0; i < validationErrors.Count; i++)
                        Console.WriteLine($"{i + 1}. {validationErrors[i]}");
                }
            }
            else
            {
                Console.WriteLine("❌ Failed to add teacher to the database.");
            }
        }

    }
}
