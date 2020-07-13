
USE [$(dbName)]
Go

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = '30DaysFromAnnualAnniversaryEmailer')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('30-Days from Annual Anniversary Emailer' ,'30DaysFromAnnualAnniversaryEmailer' ,'30-Days from Annual Anniversary Emailer' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = '30-Days from Annual Anniversary Emailer'
		,[NotificationTypeNameAlias] = '30DaysFromAnnualAnniversaryEmailer'
		,[Description] = '30-Days from Annual Anniversary Emailer'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = '30DaysFromAnnualAnniversaryEmailer'
end



If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = '1WeekAfter30DayReminder')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('1 Week After 30-day Reminder' ,'1WeekAfter30DayReminder' ,'1 Week After 30-day Reminder' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = '1 Week After 30-day Reminder'
		,[NotificationTypeNameAlias] = '1WeekAfter30DayReminder'
		,[Description] = '1 Week After 30-day Reminder'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = '1WeekAfter30DayReminder'
end


If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = '2WeeksAfter30DayReminder')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('2 Weeks After 30 Day Reminder' ,'2WeeksAfter30DayReminder' ,'2 Weeks After 30 Day Reminder' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = '2 Weeks After 30 Day Reminder'
		,[NotificationTypeNameAlias] = '2WeeksAfter30DayReminder'
		,[Description] = '2 Weeks After 30 Day Reminder'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = '2WeeksAfter30DayReminder'
end


If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'OnOneYearAnniversaryDate')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('On One-Year Anniversary Date' ,'OnOneYearAnniversaryDate' ,'On One-Year Anniversary Date' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'On One-Year Anniversary Date'
		,[NotificationTypeNameAlias] = 'OnOneYearAnniversaryDate'
		,[Description] = 'On One-Year Anniversary Date'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'OnOneYearAnniversaryDate'
end
