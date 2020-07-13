USE [$(dbName)]
GO

Alter TABLE [dbo].[TblCustomerProfileHistory]
ADD  EnableEmail BIT NOT NULL CONSTRAINT DF_TblCustomerProfileHistory_EnableEmail DEFAULT 1
	,EnableEmailUpdateDate DATETIME

GO