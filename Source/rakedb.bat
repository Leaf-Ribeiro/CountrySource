@ECHO OFF
SET ENVIRONMENT=dev
SET TASK=migrate
SET PARAM1=""
if NOT "%1" == "" SET ENVIRONMENT=%1
if NOT "%2" == "" SET TASK=%2
if NOT "%3" == "" SET PARAM1=-D:version=%3
	
@.\Utility\NAnt.0.92.0\tools\NAnt.exe -buildfile:Migrate.build migrate -D:environment=%ENVIRONMENT% -D:task=%TASK% %PARAM1%

PAUSE > NUL