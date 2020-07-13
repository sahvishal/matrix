USE [$(dbName)]
GO

Alter Table tblCustomerProfileHistory

Add MergedCustomerId bigint NULL,
EligibilityForYear int NULL   

GO