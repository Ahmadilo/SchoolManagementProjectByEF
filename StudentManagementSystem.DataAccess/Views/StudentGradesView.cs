using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("vw_StudentGradesClean")] // اسم الـ VIEW في قاعدة البيانات
public class StudentGradesView
{
    // بيانات الطالب
    [Key]
    public int StudentID { get; set; }
    public int PersonID { get; set; }
    public string EnrollmentNumber { get; set; }
    public DateTime? EnrollmentDate { get; set; }
    public int? ParentID { get; set; }
    public int? CurrentGradeLevel { get; set; }

    // بيانات تسجيل الطالب في الصف
    public int? StudentClassID { get; set; }  // نستخدم StudentClassID كمفتاح أساسي أو جزء منه
    public DateTime? StudentClassEnrollmentDate { get; set; }

    // بيانات الصف
    public int? ClassID { get; set; }
    public string ClassName { get; set; }
    public int? GradeLevel { get; set; }
    public int? AcademicYear { get; set; }
    public int? HomeroomTeacherID { get; set; }

    // بيانات مادة الصف
    public int? ClassSubjectID { get; set; }
    public int? TeacherID { get; set; }
    public string ScheduleDay { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string RoomNumber { get; set; }

    // بيانات المادة
    public string SubjectName { get; set; }
    public string SubjectCode { get; set; }
    public string Description { get; set; }
    public string Department { get; set; }

    // بيانات الدرجات
    public int? GradeID { get; set; }
    public string GradeType { get; set; }
    public DateTime? GradDate { get; set; }
    public decimal? Score { get; set; }
    public decimal? MaxScore { get; set; }
    public decimal? Weight { get; set; }
    public string Comments { get; set; }
}
