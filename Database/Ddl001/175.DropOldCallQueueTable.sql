USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueNotificationPhone_TblCallQueue]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueNotificationPhone]'))
ALTER TABLE [dbo].[TblCallQueueNotificationPhone] DROP CONSTRAINT [FK_TblCallQueueNotificationPhone_TblCallQueue]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueNotificationPhone_TblNotificationPhone]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueNotificationPhone]'))
ALTER TABLE [dbo].[TblCallQueueNotificationPhone] DROP CONSTRAINT [FK_TblCallQueueNotificationPhone_TblNotificationPhone]
GO

/****** Object:  Table [dbo].[TblCallQueueNotificationPhone]    Script Date: 02/06/2014 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueueNotificationPhone]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallQueueNotificationPhone]
GO

-------------------------------------
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallNotification_TblCalls]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallNotification]'))
ALTER TABLE [dbo].[TblCallNotification] DROP CONSTRAINT [FK_TblCallNotification_TblCalls]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallNotification_TblNotification]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallNotification]'))
ALTER TABLE [dbo].[TblCallNotification] DROP CONSTRAINT [FK_TblCallNotification_TblNotification]
GO


/****** Object:  Table [dbo].[TblCallNotification]    Script Date: 02/06/2014 17:59:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallNotification]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallNotification]
GO

----------------------------------------
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueAssignment_TblCallCenterRepProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueAssignment]'))
ALTER TABLE [dbo].[TblCallQueueAssignment] DROP CONSTRAINT [FK_TblCallQueueAssignment_TblCallCenterRepProfile]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueAssignment_TblCallQueue]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueAssignment]'))
ALTER TABLE [dbo].[TblCallQueueAssignment] DROP CONSTRAINT [FK_TblCallQueueAssignment_TblCallQueue]
GO

/****** Object:  Table [dbo].[TblCallQueueAssignment]    Script Date: 02/06/2014 18:01:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueueAssignment]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallQueueAssignment]
GO

-------------------------------
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCallQueue_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblCallQueue] DROP CONSTRAINT [DF_TblCallQueue_IsActive]
END

GO

/****** Object:  Table [dbo].[TblCallQueue]    Script Date: 02/06/2014 18:05:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueue]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallQueue]
GO

