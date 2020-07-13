USE [$(dbName)]
Go

Insert Into TblLab
	(Name, Alias, DateCreated, CreatedByOrgRoleUserId, IsActive)
Values 
	('LABCORP', 'LABCORP', GETDATE(), 1, 1),
	('QUEST', 'LABCORP', GETDATE(), 1, 1)
	
GO

Insert Into TblLanguage
	(Name, Alias, DateCreated, CreatedByOrgRoleUserId, IsActive)
Values 
	('CAMBODIAN', 'CAMBODIAN', GETDATE(), 1, 1),
	('ENGLISH', 'ENGLISH', GETDATE(), 1, 1),
	('SPANISH', 'SPANISH', GETDATE(), 1, 1),
	('TAIWANESE', 'TAIWANESE', GETDATE(), 1, 1),
	('VIETNAMESE', 'VIETNAMESE', GETDATE(), 1, 1)