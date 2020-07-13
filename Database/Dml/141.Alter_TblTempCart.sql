USE [$(dbName)]
Go

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_Smoker_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_OverWeight_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_HighCholestrol_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_HighBloodPressure_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_HearthDisease_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_DiagnosedHeartProblem_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_Diabetic_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_ChestPain_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_AgeOverPreQualificationQuestion_Lookup]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [DF_TblTempCart_SkipPreQualificationQuestion]
GO

ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [DF_TblTempCart_AgreedWithPrequalificationQuestion]
GO


 

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [Smoker]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [OverWeight]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [HighCholestrol]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [HighBloodPressure]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [HeartDisease]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [DiagnosedHeartProblem]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [Diabetic]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [ChestPain]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [AgeOverPreQualificationQuestion]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [SkipPreQualificationQuestion]
GO

ALTER TABLE [dbo].[TblTempCart] DROP COLUMN [AgreedWithPrequalificationQuestion]