@ECHO [%CMDNAME%] PREBUILD STAGE - starting

call %CLIDIR%PreBuildStage.VsDevPrompt.bat
if ERRORLEVEL 1 EXIT /B 1

call %CLIDIR%PreBuildStage.MsBuild.bat
if ERRORLEVEL 1 EXIT /B 1

@ECHO [%CMDNAME%] PREBUILD STAGE - succeeded


