
USE [$(dbName)]
Go

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'PurchaseShippingNotification')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Purchase Shipping Notification' ,'PurchaseShippingNotification' ,'Purchase Shipping Notification' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Purchase Shipping Notification'
		,[NotificationTypeNameAlias] = 'PurchaseShippingNotification'
		,[Description] = 'Purchase Shipping Notification'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'PurchaseShippingNotification'
end

Declare @NotificationTypeId bigint 
select @NotificationTypeId = NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'PurchaseShippingNotification'

if Not Exists(select * from TblNotificationSubscribers where NotificationTypeId = @NotificationTypeId)
begin
	insert into TblNotificationSubscribers
		(NotificationTypeId, Name, Email, Phone, UserId, DateCreated, DateModified, IsActive)
	values
		(@NotificationTypeId,'HealthFair Support', 'gaurav@taazaa.com', null, null, getdate(), getdate(), 1)
end
else
begin
	update TblNotificationSubscribers
	set Email = 'gaurav@taazaa.com'
	where NotificationTypeId = @NotificationTypeId
end




