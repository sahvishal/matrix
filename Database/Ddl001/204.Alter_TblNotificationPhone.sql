USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblNotificationPhone] Drop  CONSTRAINT [DF_TblNotificationPhone_DeadLine]  
GO

ALTER TABLE [dbo].[TblNotificationPhone] DROP  CONSTRAINT [DF_TblNotificationPhone_ProspectCustomerID]  
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[DF_TblNotificationPhone_ProspectCustomerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblNotificationPhone]'))
ALTER TABLE [dbo].[TblNotificationPhone] DROP CONSTRAINT [DF_TblNotificationPhone_ProspectCustomerID]
GO

ALTER TABLE [dbo].[TblNotificationPhone] DROP COLUMN CallersFullName,PhoneOffice,PhoneHome, IsAutoDial,CallType,DeadLine, ProspectCustomerID,CallParameters
GO


ALTER TABLE TblNotificationType ADD NotificationMediumId Int NULL 
Go

ALTER TABLE [dbo].[TblNotificationType]  WITH CHECK ADD  CONSTRAINT [FK_TblNotification_TblNotificationMedium] FOREIGN KEY([NotificationMediumId])
REFERENCES [dbo].[TblNotificationMedium] ([NotificationMediumID])
GO

