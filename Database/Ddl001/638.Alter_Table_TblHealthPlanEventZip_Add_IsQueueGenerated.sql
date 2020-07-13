USE [$(dbName)]
GO

ALTER TABLE TblHealthPlanEventZip ADD IsQueueGenerated BIT NOT NULL DEFAULT 1;