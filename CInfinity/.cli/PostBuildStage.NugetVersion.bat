@REM ------------------------------------------------------------------------------
@REM SECTION: Version of the build

SET NUGETVERSIONFILE=%NUGETSPECSDIR%\NugetVersion.txt

if EXIST "%NUGETVERSIONFILE%" (
    REM @ECHO [%CMDNAME%] Using version number from file %NUGETVERSIONFILE%
    FOR /F "usebackq tokens=1,2,3,4 delims=." %%i in (`type "%NUGETVERSIONFILE%"`) do set NUGETVERSION=%%i.%%j.%%k
) else (
    @ECHO [%CMDNAME%] Unable to read version number from file %VERSIONFILE%
    SET NUGETVERSION=1.0
)

@ECHO [%CMDNAME%] Version: %NUGETVERSION%
