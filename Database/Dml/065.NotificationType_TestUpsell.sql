

USE [$(dbName)]
Go

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'TestUpsellNotification')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Test Upsell Notification' ,'TestUpsellNotification' ,'Test Upsell Notification' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Test Upsell Notification'
		,[NotificationTypeNameAlias] = 'TestUpsellNotification'
		,[Description] = 'Test Upsell Notification'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'TestUpsellNotification'
end
