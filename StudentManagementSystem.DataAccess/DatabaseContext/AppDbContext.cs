using System.Data.Entity;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Views;

namespace StudentManagementSystem.DataAccess.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppDbContext") // هذا يستخدم الاتصال من Web.config أو App.config
        {

        }

        static AppDbContext()
        {
            // يمنع EF من محاولة إنشاء أو تعديل قاعدة البيانات
            Database.SetInitializer<AppDbContext>(null);
        }

        // هذه النافذة التي تطل على جدول Users
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SchoolClass> Classes { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<ClassSubjectForTeacher> ClassSubjectsWithTeachers { get; set; }
        public DbSet<StudentClassDetails> StudentClassDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // تأكد من تعريف مفتاح رئيسي للـ View
            modelBuilder.Entity<ClassSubjectForTeacher>().HasKey(c => c.SubjectID);
            modelBuilder.Entity<StudentClassDetails>().HasKey(s => s.StudentID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
