@REM ------------------------------------------------------------------------------
@REM SECTION: Developer Command Prompt for Visual Studio

if "%VisualStudioVersion%" == "" (
    @REM Try to find VS command prompt init script
    where /Q VsDevCmd.bat
    if ERRORLEVEL 1 (
        if exist "%VS140COMNTOOLS%" (
            call "%VS140COMNTOOLS%VsDevCmd.bat"
        )
    ) else (
        @REM VsDevCmd.bat is in PATH, so just exec it.
        VsDevCmd.bat
    )
)

if "%VisualStudioVersion%" == "" (
    ECHO [%CMDNAME%] Could not determine Visual Studio version in the system. Cannot continue.
    exit /b 1
)

@ECHO [%CMDNAME%] Visual Studio command prompt initialized
