USE [$(dbName)]
GO

Declare @NotificationMediumId int
INSERT INTO TblNotificationMedium
           (NotificationMedium
           ,Description
           ,DateCreated
           ,DateModified)
     VALUES
           ('Fax','Fax Notification',GETDATE(),GETDATE())

Set @NotificationMediumId = @@IDENTITY

INSERT INTO TblNotificationType
           (NotificationTypeName
           ,NotificationTypeNameAlias
           ,Description
           ,DateCreated
           ,DateModified
           ,IsActive
           ,NoOfAttempts
           ,IsServiceEnabled
           ,IsQueuingEnabled
           ,ModifiedByOrgRoleUserId
           ,NotificationMediumId)
     VALUES
           ('Fax Result Notification','FaxResultNotification','Fax Result Notification',GETDATE(),GETDATE(),1,1,0,0,1,@NotificationMediumId)
GO


