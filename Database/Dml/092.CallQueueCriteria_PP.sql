USE [$(dbName)]
Go

SET IDENTITY_INSERT [TblCriteria] ON
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (13, 'Physician Partner', 1)

SET IDENTITY_INSERT [TblCriteria] OFF