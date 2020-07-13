USE [$(dbName)]
GO

ALTER TABLE dbo.TblEventCustomers ADD
	InsuranceReleaseStatus [smallint] NOT NULL Constraint DF_TblEventCustomers_InsuranceReleaseStatus default 0	
GO
