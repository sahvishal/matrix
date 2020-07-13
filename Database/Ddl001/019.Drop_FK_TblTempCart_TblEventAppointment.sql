USE [$(dbName)]
Go

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblTempCart_TblEventAppointment]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblTempCart]'))
ALTER TABLE [dbo].[TblTempCart] DROP CONSTRAINT [FK_TblTempCart_TblEventAppointment]
GO


