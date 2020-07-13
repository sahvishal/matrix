USE [$(dbname)]
GO

SET IDENTITY_INSERT TblActivityType ON

INSERT TblActivityType (Id,Name,Alias,IsActive,CreatedBy,CreatedDate)
VALUES (1,'Only Mail','OnlyMail',1,1,GETDATE()),
	   (2,'Only Call','OnlyCall',1,1,GETDATE()),
	   (3,'Both Mail And Call','BothMailAndCall',1,1,GETDATE()),
	   (4,'Do not Call/Do not Email','DoNotCallDoNotMail',1,1,GETDATE())

SET IDENTITY_INSERT TblActivityType OFF
