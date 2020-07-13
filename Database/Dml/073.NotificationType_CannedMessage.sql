
USE [$(dbName)]
Go

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'CannedMessageNotification')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Canned Message Notification' ,'CannedMessageNotification' ,'Canned Message Notification' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Canned Message Notification'
		,[NotificationTypeNameAlias] = 'CannedMessageNotification'
		,[Description] = 'Canned Message Notification'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'CannedMessageNotification'
end
