SET dbName=Falcon
SET dbFilePath=C:\DBs\

for /f %%a IN ('dir /s /b *.sql') do call runner.bat %%~pa%%~na %%~xa


PAUSE


