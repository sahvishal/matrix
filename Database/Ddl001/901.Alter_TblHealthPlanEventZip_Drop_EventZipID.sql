USE [$(dbName)]
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[TblHealthPlanEventZip]') AND name = N'IX_TblHealthPlanEventZip_AId')
DROP INDEX [IX_TblHealthPlanEventZip_AId] ON [dbo].[TblHealthPlanEventZip]
GO

ALTER TABLE TblHealthPlanEventZip
DROP COLUMN EventZipID
GO