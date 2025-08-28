@echo off

:: Run tests and check if they pass
dotnet test
if %errorlevel%==0 (
    echo ✅ All tests passed.

    :: Prompt for commit message
    set /p commitMessage="Enter your commit message: "
    git add .
    git commit -m "%commitMessage%"
) else (
    echo ❌ Tests failed. Reverting changes...
    git reset --hard
)