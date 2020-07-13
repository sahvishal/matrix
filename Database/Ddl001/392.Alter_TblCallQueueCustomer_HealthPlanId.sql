
USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCallQueueCustomer ADD
	HealthPlanId bigint NULL CONSTRAINT FK_TblCallQueueCustomer_TblAccount FOREIGN KEY (HealthPlanId) REFERENCES dbo.TblAccount	(AccountId)
GO
