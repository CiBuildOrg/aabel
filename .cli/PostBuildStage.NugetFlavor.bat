@REM ------------------------------------------------------------------------------
@REM SECTION: Flavor or the packages

SET NUGETPACKAGESDIR=%SOLUTIONDIR%\.nugetpkgs

if "%CONFIGURATION%" == "Release" (
	SET NUGETPRERELEASE=false
	SET NUGETDROPDIR=%NUGETPACKAGESDIR%
) else (
	SET NUGETPRERELEASE=true
	SET NUGETDROPDIR=%NUGETPACKAGESDIR%\Prerelease
)

@ECHO [%CMDNAME%] Prerelease: %NUGETPRERELEASE%
@ECHO [%CMDNAME%] Drop location: %NUGETDROPDIR%

if exist "%NUGETDROPDIR%" GOTO :EOF

mkdir "%NUGETDROPDIR%"

