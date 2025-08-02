حسنا أنا بحاجة إلى مكتبة يمكنه أن تولد لي بيانات مزيف وتستطيع حذفه أيضا في نفس الوقت وقت

وتحتوي على قدةر على توليد كل عناصر المتاح مع قدرة على توليد بيانات عشوائية وسيناريوهات مختلفة.

وهم من ذلك قدرة على حذف هذه بيانات بعد نهاية الاختبار.

## Code Base

```C#
static CreateUser() => returen clsUser;
static CreatePerosn() => return clsPerson;
static CreateStudent() => return clsStudent;
static CreateStaff() => return clsStaff;
static CeateTeacher() => return clsTeacher;

static CeateClass() => return clsSchoolClass;
static CeateSubject() => return clsSubject;


static CreateStudentClass => return clsStudentClass;
static CreateClassSubject => return clsClassSubject;

static CreateAttendance() => return clsAttendance;

static CreateGrade() => return clsGrade;
```

## Library Structure

```C#
DataGenrater Library:
	├── DataGenrater.csproj
	├── DataGenrater.cs
	├── DataGeneratorPublic.cs
	├── SynarioGenerator
	│		├── AddUsers.cs
	│		└── ...
	├── BaseGenerator
	│		├── BaseGenerator.cs
	│		└── BaseDelete.cs
```