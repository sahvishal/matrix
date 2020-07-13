 USE [$(dbname)]
 GO
declare @notificationMediumId bigint
select @notificationMediumId= NotificationMediumID  from TblNotificationMedium where NotificationMedium='Email'

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'AbsenceByMember')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId],[NotificationMediumId])
	values
		('AbsenceByMember Template' ,'AbsenceByMember' ,'AbsenceByMember Template' ,getdate() ,getdate() ,1 ,1 ,1 ,1 ,null,@notificationMediumId)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'AbsenceByMember Template'
		,[NotificationTypeNameAlias] = 'AbsenceByMember'
		,[Description] = 'AbsenceByMember Template'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 1 
		,[IsQueuingEnabled] = 1
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'AbsenceByMember'
end
GO

