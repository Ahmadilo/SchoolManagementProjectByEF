@echo off
setlocal enabledelayedexpansion

:: التحقق من تمرير المعاملات
set "BRANCH=%~1"
set "COMMENT=%~2"

if "%BRANCH%"=="" (
    echo The BRANCH Name is not provided.
    echo Use gitpush.bat branch_name "commit message"
    exit /b
)

if "%COMMENT%"=="" (
    echo The COMMIT Message is not provided.
    echo Use gitpush.bat branch_name "commit message"
    exit /b
)

:: عرض حالة Git
echo --- Status of the Git repository ---
git status

:: تأكيد من المستخدم
set /p confirm=Do you Want to continue with the commit and push to branch "%BRANCH%"? (y/n): 

if /i not "%confirm%"=="y" if /i not "%confirm%"=="Y" (
    echo The operation has been cancelled.
    exit /b
)

:: تنفيذ العمليات
echo ➕ إضافة الملفات...
git add .

echo 📝 إنشاء الكوميت...
git diff --cached --quiet
if errorlevel 1 (
    git commit -m "%COMMENT%"
) else (
    echo No changes to commit.
    exit /b
)

echo Pushing changes to origin/%BRANCH% ...
git push origin %BRANCH%

echo --------------------------------------
echo ✅ Commit created and pushed to branch %BRANCH%.
pause