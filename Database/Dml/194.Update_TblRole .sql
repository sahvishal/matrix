USE [$(dbName)]
GO

UPDATE [dbo].[TblRole]  SET IsSystemRole=0 where RoleID=9
	
GO
