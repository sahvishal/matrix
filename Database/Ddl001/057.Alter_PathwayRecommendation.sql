
USE [$(dbName)]
Go

ALTER TABLE dbo.TblCustomerEventTestState ADD PathwayRecommendation bigint NULL
GO

ALTER TABLE dbo.TblEventCustomerResult ADD PathwayRecommendation bigint NULL
GO
