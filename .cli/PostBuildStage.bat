@ECHO [%CMDNAME%] POSTBUILD STAGE - starting

call %CLIDIR%PostBuildStage.Nuget.bat
if ERRORLEVEL 1 EXIT /B 1

@ECHO [%CMDNAME%] POSTBUILD STAGE - succeeded
