
USE [$(dbName)]
Go
declare @notificationMediumId bigint
select @notificationMediumId= NotificationMediumID  from TblNotificationMedium where NotificationMedium='Email'

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'CustomerTaggedForDifferentTaggedEvent')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId],[NotificationMediumId])
	values
		('Customer Tagged For Different Tagged Event' ,'CustomerTaggedForDifferentTaggedEvent' ,'Customer Tagged For Different Tagged Event' ,getdate() ,getdate() ,1 ,1 ,1 ,1 ,null,@notificationMediumId)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Customer Tagged For Different Tagged Event'
		,[NotificationTypeNameAlias] = 'CustomerTaggedForDifferentTaggedEvent'
		,[Description] = 'Customer Tagged For Different Tagged Event'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 1 
		,[IsQueuingEnabled] = 1
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'CustomerTaggedForDifferentTaggedEvent'
end
