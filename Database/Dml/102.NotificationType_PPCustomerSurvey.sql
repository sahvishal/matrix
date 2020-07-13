
USE [$(dbName)]
Go
declare @notificationMediumId bigint
select @notificationMediumId= NotificationMediumID  from TblNotificationMedium where NotificationMedium='Email'

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'PhysicianPartnerSurveyEmailNotification')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId],[NotificationMediumId])
	values
		('Physician partners Customer Survey Email Notification' ,'PhysicianPartnerSurveyEmailNotification' ,'Physician partners Customer Survey Email Notification' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null,@notificationMediumId)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Physician partners Customer Survey Email Notification'
		,[NotificationTypeNameAlias] = 'PhysicianPartnerSurveyEmailNotification'
		,[Description] = 'Physician partners Customer Survey Email Notification'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'PhysicianPartnerSurveyEmailNotification'
end