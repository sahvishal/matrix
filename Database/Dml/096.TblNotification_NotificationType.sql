USE [$(dbName)]
GO

UPDATE TblNotificationType Set NotificationMediumId =1 WHERE NotificationTypeID > 0
Go

ALTER TABLE TblNotificationType ALTER COLUMN NotificationMediumId Int NOT NULL
GO

