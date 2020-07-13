
USE [$(dbName)]
GO

ALTER TABLE dbo.TblCustomerHealthInfo ADD
	EventCustomerId bigint NULL
GO

ALTER TABLE [dbo].[TblCustomerHealthInfo]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfo_TblEventCustomers] FOREIGN KEY(EventCustomerId)
REFERENCES [dbo].[TblEventCustomers] (EventCustomerId)
GO

ALTER TABLE dbo.TblCustomerHealthInfo
	DROP CONSTRAINT PK_TblCustomerHealthInfo
GO

ALTER TABLE dbo.TblCustomerHealthInfoArchive ADD
	EventCustomerId bigint NULL
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoArchive]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfoArchive_TblEventCustomers] FOREIGN KEY(EventCustomerId)
REFERENCES [dbo].[TblEventCustomers] (EventCustomerId)
GO


