
USE [$(dbName)]
Go

declare @notificationMediumId bigint
select @notificationMediumId= NotificationMediumID  from TblNotificationMedium where NotificationMedium='Email'

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'PhysicianPartnersCustomerResultReady')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId],[NotificationMediumId])
	values
		('Physician Partners Customer Result Ready' ,'PhysicianPartnersCustomerResultReady' ,'Physician Partners Customer Result Ready' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null,@notificationMediumId)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Physician Partners Customer Result Ready'
		,[NotificationTypeNameAlias] = 'PhysicianPartnersCustomerResultReady'
		,[Description] = 'Physician Partners Customer Result Ready'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'PhysicianPartnersCustomerResultReady'
end

