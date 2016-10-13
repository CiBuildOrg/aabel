@SETLOCAL EnableExtensions EnableDelayedExpansion
@ECHO off

@REM ------------------------------------------------------------------------------
@REM SECTION: Parsing the arguments

if "%1" == "debug" (
	SET CONFIGURATION=Debug
) else if "%1" == "release" (
	SET CONFIGURATION=Release
)

if "%CONFIGURATION%" == "" GOTO Usage

if %2. == . GOTO Usage
SET NUGETDROPDIR=%2

@REM ------------------------------------------------------------------------------
@REM SECTION: Initializing loval variables

SET CMDNAME=Build
SET CLIDIR=%~dp0
SET SOLUTIONDIR=%CLIDIR%..

@ECHO [%CMDNAME%] MASTER BUILD - starting

@REM ------------------------------------------------------------------------------
@REM SECTION: Running the pre build

call %CLIDIR%PreBuildStage.bat
if ERRORLEVEL 1 EXIT /B 1

@REM ------------------------------------------------------------------------------
@REM SECTION: Running the build stage

@ECHO [%CMDNAME%]
call %CLIDIR%BuildStage.bat
if ERRORLEVEL 1 EXIT /B 1

@REM ------------------------------------------------------------------------------
@REM SECTION: Running the post build stage

@ECHO [%CMDNAME%]
call %CLIDIR%PostBuildStage.bat
if ERRORLEVEL 1 EXIT /B 1

@ECHO [%CMDNAME%]
@ECHO [%CMDNAME%] MASTER BUILD - succeeded

GOTO :EOF

:Usage
@ECHO Usage:
@ECHO    build ^<flavor^> droppkgs
@ECHO where:
@ECHO    flavor: debug, release
@ECHO    droppkgs: the location where the nuget packages will be dropped.
EXIT /B -1

:EOF