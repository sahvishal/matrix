USE [$(dbName)]
Go

SET IDENTITY_INSERT [TblCriteria] ON

Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (1, 'All Prospects', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (2, 'All Customers', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (3, 'All Customers older than one year', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (4, 'No Show Customers', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (5, 'Cancelled  Customers', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (6, 'Online Drop Off', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (7, 'Call Center Drop Off', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (8, 'Non Serviced zip code', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (9, 'Pricing concerns', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (10, 'Insurance concern', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (11, 'Morning appointment preferred', 1)
	
Insert Into TblCriteria (CriteriaId, Name, IsActive)
Values (12, 'Afternoon appointment preferred', 1)

SET IDENTITY_INSERT [TblCriteria] OFF