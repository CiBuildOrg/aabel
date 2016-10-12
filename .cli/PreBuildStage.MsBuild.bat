@REM ------------------------------------------------------------------------------
@REM SECTION: MS Build

if exist "%ProgramFiles%\MSBuild\14.0\bin" SET MSBUILDEXEDIR=%ProgramFiles%\MSBuild\14.0\bin
if exist "%ProgramFiles(x86)%\MSBuild\14.0\bin" SET MSBUILDEXEDIR=%ProgramFiles(x86)%\MSBuild\14.0\bin

@REM Can't multi-block if statement when check condition contains '(' and ')' char, so do as single line checks
if NOT "%MSBUILDEXEDIR%" == "" SET MSBUILDEXE=%MSBUILDEXEDIR%\MSBuild.exe
if NOT "%MSBUILDEXEDIR%" == "" GOTO :MsBuildFound

@REM Try to find VS command prompt init script
where /Q MsBuild.exe
if ERRORLEVEL 1 (
    ECHO [%CMDNAME%] Could not find MSBuild in the system. Cannot continue.
    EXIT /b 1
) else (
    @REM MsBuild.exe is in PATH, so just use it.
   SET MSBUILDEXE=MSBuild.exe
 )

:MsBuildFound
@ECHO [%CMDNAME%] Using %MSBUILDEXE% for building
