
USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCallQueue 
ADD IsManual bit NOT NULL CONSTRAINT DF_TblCallQueue_IsManual DEFAULT 1,
Category varchar(255) NULL 
GO

ALTER TABLE dbo.TblCallQueueCustomer ADD
	EventId bigint NULL CONSTRAINT FK_TblCallQueueCustomer_TblEvents FOREIGN KEY (EventId) REFERENCES dbo.TblEvents	(EventID)
GO
