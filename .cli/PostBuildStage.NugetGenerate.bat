@REM ------------------------------------------------------------------------------
@REM SECTION: Generate nuget packages

SET NUGETURI=%SOLUTIONDIR%\.nuget\nuget.exe

FOR %%G IN ("%NUGETSPECSDIR%\*.nuspec") DO (
  "%NUGETURI%" pack "%%G" %NUGETOPTIONS%
  if ERRORLEVEL 1 EXIT /B 1
)
