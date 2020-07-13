USE [$(dbName)]
Go

Declare @NotificationTypeId int
select @NotificationTypeId = NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'CustomerTaggedForDifferentTaggedEvent'


INSERT INTO TblNotificationSubscribers (NotificationTypeID,Name,Email,DateCreated,DateModified,IsActive)
 VALUES(@NotificationTypeID,'Health Fair','registrationoverride@healthfair.com',getdate(),getdate(),1)