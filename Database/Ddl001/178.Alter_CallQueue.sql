
USE [$(dbName)]
GO

Alter Table TblCallQueue Add IsQueueGenerated bit NOT NULL Constraint DF_TblCallQueue_IsQueueGenerated default 0
GO

Alter Table TblCallQueue Add QueueGenerationInterval int NULL
GO

Alter Table TblCallQueue Add LastQueueGeneratedDate datetime NULL
GO
