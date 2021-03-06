USE [master]
IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = 'falconUser')
BEGIN
    CREATE LOGIN [falconUser] WITH PASSWORD=N'Screening!', DEFAULT_DATABASE=[$(dbName)], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
END

USE [$(dbName)]
GO
CREATE USER [falconUser] FOR LOGIN [falconUser]
GO
USE [$(dbName)]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_owner] TO [falconUser]
GO
USE [$(dbName)]
GO
EXEC sp_addrolemember N'db_owner', N'falconUser'
GO
