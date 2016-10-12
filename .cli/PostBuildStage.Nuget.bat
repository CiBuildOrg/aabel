@ECHO [%CMDNAME%] Nuget Package Generation - starting

@REM ------------------------------------------------------------------------------
@REM SECTION: package flavor

call %CLIDIR%PostBuildStage.NugetFlavor.bat
if ERRORLEVEL 1 EXIT /B 1

@REM ------------------------------------------------------------------------------
@REM SECTION: package version

SET NUGETSPECSDIR=%SOLUTIONDIR%\.nugetspecs

call %CLIDIR%PostBuildStage.NugetVersion.bat
if ERRORLEVEL 1 EXIT /B 1

@REM ------------------------------------------------------------------------------
@REM SECTION: package options

call %CLIDIR%PostBuildStage.NugetOptions.bat
if ERRORLEVEL 1 EXIT /B 1

@REM ------------------------------------------------------------------------------
@REM SECTION: generating nuget packages

call %CLIDIR%PostBuildStage.NugetGenerate.bat
if ERRORLEVEL 1 EXIT /B 1

@ECHO [%CMDNAME%] Nuget Package Generation - succeeded
