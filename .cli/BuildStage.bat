@ECHO [%CMDNAME%] BUILD STAGE - starting

SET BINARIESPATH=.bins
SET OUTDIR=%SOLUTIONDIR%\%BINARIESPATH%\%CONFIGURATION%
SET SOLUTIONNAME=CInfinity.sln
SET SOLUTIONFILE=%SOLUTIONDIR%\%SOLUTIONNAME%

@ECHO [%CMDNAME%] Solution directory: %SOLUTIONDIR%
@ECHO [%CMDNAME%] Solution file: %SOLUTIONFILE%
@ECHO [%CMDNAME%] Building %SOLUTIONNAME%, flavor %CONFIGURATION%
@ECHO [%CMDNAME%] Drop location: %OUTDIR% 
@ECHO [%CMDNAME%]

"%MSBUILDEXE%" /nr:False /nologo /v:n /m /p:Configuration=%CONFIGURATION% "%SOLUTIONFILE%"
@if ERRORLEVEL 1 GOTO :BuildError
@echo [%CMDNAME%] Build succeeded for %CONFIGURATION% %SOLUTIONFILE%

@REM ------------------------------------------------------------------------------
@REM SECTION: Build succeeded

:BuildSucceeded
@ECHO [%CMDNAME%]
@ECHO [%CMDNAME%] BULDING STAGE - succeeded
GOTO :EOF

@REM ------------------------------------------------------------------------------
@REM SECTION: Build failed

:BuildError
set RC=%ERRORLEVEL%
if "%STEP%" == "" set STEP=%CONFIGURATION%
@ECHO [%CMDNAME%]
@ECHO [%CMDNAME%] BULDING STAGE - failed - %STEP% with error %RC% - Cannot continue
exit /B %RC%
GOTO :EOF

