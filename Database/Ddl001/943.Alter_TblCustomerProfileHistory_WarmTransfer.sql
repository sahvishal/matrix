USE [$(dbName)]
GO

Alter TABLE [dbo].[TblCustomerProfileHistory]
ADD  IsWarmTransfer BIT NULL
	,WarmTransferYear INT NULL

GO