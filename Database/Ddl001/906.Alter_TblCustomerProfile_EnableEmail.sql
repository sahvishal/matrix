USE [$(dbName)]
GO

Alter TABLE [dbo].[TblCustomerProfile]
ADD  EnableEmail BIT NOT NULL CONSTRAINT DF_TblCustomerProfile_EnableEmail DEFAULT 1
	,EnableEmailUpdateDate DATETIME

GO