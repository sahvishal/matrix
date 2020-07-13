
USE [$(dbName)]
Go
declare @notificationMediumId bigint
select @notificationMediumId= NotificationMediumID  from TblNotificationMedium where NotificationMedium='SMS'

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'LoginOTPSmsNotification')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId],[NotificationMediumId])
	values
		('Login OTP SMS Notification' ,'LoginOTPSmsNotification' ,'Login OTP SMS Notification' ,getdate() ,getdate() ,1 ,1 ,1 ,1 ,null,@notificationMediumId)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Login OTP SMS Notification'
		,[NotificationTypeNameAlias] = 'LoginOTPSmsNotification'
		,[Description] = 'Login OTP SMS Notification'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 1 
		,[IsQueuingEnabled] = 1
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'LoginOTPSmsNotification'
end
