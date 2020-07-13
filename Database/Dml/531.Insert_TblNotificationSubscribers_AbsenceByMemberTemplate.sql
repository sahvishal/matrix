USE [$(dbname)]
GO


Declare @notificationTypeId bigint

Select @notificationTypeId= NotificationTypeID  from TblNotificationType where NotificationTypeNameAlias='AbsenceByMember'

IF NOT EXISTS (SELECT * FROM TblNotificationSubscribers WHERE NotificationTypeID =@notificationTypeId)
BEGIN	
	INSERT INTO TblNotificationSubscribers	(NotificationTypeID,Name,Email,DateCreated,IsActive) 
		VALUES (@notificationTypeId,'HealthFair Support','rohit.saini@taazaa.com',GETDATE(),1) 

	INSERT INTO TblNotificationSubscribers	(NotificationTypeID,Name,Email,DateCreated,IsActive) 
		VALUES (@notificationTypeId,'HealthFair Support','gaurav@taazaa.com',GETDATE(),1) 

		INSERT INTO TblNotificationSubscribers	(NotificationTypeID,Name,Email,DateCreated,IsActive) 
		VALUES (@notificationTypeId,'HealthFair Support','siddharth@taazaa.com',GETDATE(),1) 

		INSERT INTO TblNotificationSubscribers	(NotificationTypeID,Name,Email,DateCreated,IsActive) 
		VALUES (@notificationTypeId,'HealthFair Support','yogesh@taazaa.com',GETDATE(),1) 

END
