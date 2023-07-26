@echo off

set "outputDirectory=%~1"
set "toolVersion=%~2"
set "toolPackagePath=%~3"

set "toolName=plugintool"
set "toolCommand=plugin"

for /f "tokens=1,2" %%a in ('dotnet tool list') do (
    if "%%a"=="%toolName%" (
        if "%%b"=="%toolVersion%" (
            echo %toolName% version %toolVersion% is already installed.
            goto :run
        ) else (
            echo Found %toolName% with a different version: %%b
            echo Uninstalling %%b...
            dotnet tool uninstall %toolName%
        )
    )
)

echo Installing %toolName% version %toolVersion%...
dotnet tool install --add-source %toolPackagePath% %toolName% --version %toolVersion%

:run
echo Running %toolName% %outputDirectory%...
dotnet %toolCommand% pack -s %outputDirectory% -b

exit /b 0