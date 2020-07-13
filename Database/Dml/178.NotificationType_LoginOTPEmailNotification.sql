
USE [$(dbName)]
Go
declare @notificationMediumId bigint
select @notificationMediumId= NotificationMediumID  from TblNotificationMedium where NotificationMedium='Email'

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'LoginOTPEmailNotification')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId],[NotificationMediumId])
	values
		('Login OTP Email Notification' ,'LoginOTPEmailNotification' ,'Login OTP Email Notification' ,getdate() ,getdate() ,1 ,1 ,1 ,1 ,null,@notificationMediumId)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Login OTP Email Notification'
		,[NotificationTypeNameAlias] = 'LoginOTPEmailNotification'
		,[Description] = 'Login OTP Email Notification'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 1 
		,[IsQueuingEnabled] = 1
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'LoginOTPEmailNotification'
end
