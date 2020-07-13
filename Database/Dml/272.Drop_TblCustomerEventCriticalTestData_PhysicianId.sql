USE [$(dbName)]
Go

ALTER TABLE [TblCustomerEventCriticalTestData] DROP CONSTRAINT [TblCustomerEventCriticalTestData_TblOrganizationRoleUser_PhysicianId]
GO

ALTER TABLE TblCustomerEventCriticalTestData Drop Column PhysicianId 
GO