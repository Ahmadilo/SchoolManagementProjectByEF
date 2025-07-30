# 📊 Student Total Marks Report

This module allows teachers to generate a comprehensive report of student grades for a selected class.

---

## 🧩 Required Components

- **Service Layer**: `clsReportStudentMarksService`  
- **Template Model**: `tmpStudentMarksReport`  
- **UI Form**: `frmStudentMarksReport`  
- **Export Control**: `ucExportFile.cs` (used to export the report)

---

## 👩‍🏫 User Flow: Teacher Perspective

### ✅ Preconditions

- All student marks for the selected class **must be fully entered**.
- If **any student** is missing grades, report generation will be **disabled**.

### 🚦 Report Generation Steps

1. Teacher selects a class from the UI.
2. The system checks whether all student marks are complete.
3. If **incomplete**:
   - Report generation is blocked.
   - A message may be shown indicating that marks are missing.
4. If **complete**:
   - The system generates a tabular report displaying:
     - Student names
     - Grade categories (e.g., Participation, Exam, Project, etc.)
   - The teacher can **export the report** using the `ucExportFile.cs` control.

---

## ⚙️ Back-End Process Flow

Once a class is selected:

1. An instance of `clsReportStudentMarksService` is created.
2. The selected class is passed into the service.
3. The method `CheckRoleService()` is called to validate business logic rules.

   - Returns `true` if the rules are satisfied.
   - Returns `false` otherwise (report generation is halted).

4. If validation passes:
   - `GetStudentMarksReport()` is invoked.
   - Returns a `List<tmpStudentMarksReport>` containing the report data.

5. If validation fails:
   - `GetStudentMarksReport()` is **not** called.
   - The result will be `null`.

---

## 🧪 Method Summary

| Method Name              | Description                                                         | Status  | Return Type                      |
|--------------------------|---------------------------------------------------------------------|---------|----------------------------------|
| `CheckRoleService()`     | Validates if report generation is allowed for the selected class    | ✅      | `bool`                           |
| `GetStudentMarksReport()`| Retrieves the formatted student marks data                          | ⏳      | `List<tmpStudentMarksReport>` or `null` |

---

## 📤 Report Output

The final output is a structured, exportable report showing:

- Each student's name  
- Detailed breakdown of marks by category  
- The ability to export the report to a file (PDF, Excel, etc.) using `ucExportFile.cs`

---

> **Note**: This document is focused on the student report generation feature for teachers. Ensure all marks are reviewed before attempting report generation.