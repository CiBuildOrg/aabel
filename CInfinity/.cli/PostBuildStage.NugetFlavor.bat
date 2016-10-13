@REM ------------------------------------------------------------------------------
@REM SECTION: Flavor or the packages

SET NUGETPACKAGESDIR=%SOLUTIONDIR%\.nugetpkgs

if "%CONFIGURATION%" == "Release" (
	SET NUGETPRERELEASE=false
	@REM SET NUGETDROPDIR=%NUGETPACKAGESDIR%
) else (
	SET NUGETPRERELEASE=true
	@REM SET NUGETDROPDIR=%NUGETPACKAGESDIR%\Prerelease
	SET NUGETDROPDIR=%NUGETDROPDIR%\Prerelease
)

@ECHO [%CMDNAME%] Prerelease: %NUGETPRERELEASE%
@ECHO [%CMDNAME%] Drop location: %NUGETDROPDIR%

if exist "%NUGETDROPDIR%" GOTO :EOF

mkdir "%NUGETDROPDIR%"

