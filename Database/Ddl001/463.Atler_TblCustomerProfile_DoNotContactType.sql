USE [$(dbName)]
GO

Alter Table TblCustomerProfile 
		Add DoNotContactTypeId bigInt NULL 
GO


Alter Table [dbo].[TblCustomerProfile]
		Add Constraint FK_TblCustomerProfile_DoNotContactTypeId FOREIGN KEY([DoNotContactTypeId]) REFERENCES dbo.TblLookup (LookupId)

GO