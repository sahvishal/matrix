
USE [$(dbName)]
Go

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'OneDayAfterProspectCreationFollowup')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('One Day After Prospect Creation Followup' ,'OneDayAfterProspectCreationFollowup' ,'One Day After Prospect Creation Followup' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'One Day After Prospect Creation Followup'
		,[NotificationTypeNameAlias] = 'OneDayAfterProspectCreationFollowup'
		,[Description] = 'One Day After Prospect Creation Followup'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'OneDayAfterProspectCreationFollowup'
end



If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'OneWeekAfterProspectCreationFollowup')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('One Week After Prospect Creation Followup' ,'OneWeekAfterProspectCreationFollowup' ,'One Week After Prospect Creation Followup' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'One Week After Prospect Creation Followup'
		,[NotificationTypeNameAlias] = 'OneWeekAfterProspectCreationFollowup'
		,[Description] = 'One Week After Prospect Creation Followup'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'OneWeekAfterProspectCreationFollowup'
end


If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'TwoWeekAfterProspectCreationFollowup')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Two Week After Prospect Creation Followup' ,'TwoWeekAfterProspectCreationFollowup' ,'Two Week After Prospect Creation Followup' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Two Week After Prospect Creation Followup'
		,[NotificationTypeNameAlias] = 'TwoWeekAfterProspectCreationFollowup'
		,[Description] = 'Two Week After Prospect Creation Followup'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'TwoWeekAfterProspectCreationFollowup'
end


If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'ThreeWeekAfterProspectCreationFollowup')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Three Week After Prospect Creation Followup' ,'ThreeWeekAfterProspectCreationFollowup' ,'Three Week After Prospect Creation Followup' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Three Week After Prospect Creation Followup'
		,[NotificationTypeNameAlias] = 'ThreeWeekAfterProspectCreationFollowup'
		,[Description] = 'Three Week After Prospect Creation Followup'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'ThreeWeekAfterProspectCreationFollowup'
end

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'FourWeekAfterProspectCreationFollowup')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Four Week After Prospect Creation Followup' ,'FourWeekAfterProspectCreationFollowup' ,'Four Week After Prospect Creation Followup' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Four Week After Prospect Creation Followup'
		,[NotificationTypeNameAlias] = 'FourWeekAfterProspectCreationFollowup'
		,[Description] = 'Four Week After Prospect Creation Followup'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'FourWeekAfterProspectCreationFollowup'
end

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'FiveWeekAfterProspectCreationFollowup')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Five Week After Prospect Creation Followup' ,'FiveWeekAfterProspectCreationFollowup' ,'Five Week After Prospect Creation Followup' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Five Week After Prospect Creation Followup'
		,[NotificationTypeNameAlias] = 'FiveWeekAfterProspectCreationFollowup'
		,[Description] = 'Five Week After Prospect Creation Followup'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'FiveWeekAfterProspectCreationFollowup'
end

If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'SixWeekAfterProspectCreationFollowup')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Six Week After Prospect Creation Followup' ,'SixWeekAfterProspectCreationFollowup' ,'Six Week After Prospect Creation Followup' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Six Week After Prospect Creation Followup'
		,[NotificationTypeNameAlias] = 'SixWeekAfterProspectCreationFollowup'
		,[Description] = 'Six Week After Prospect Creation Followup'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'SixWeekAfterProspectCreationFollowup'
end


If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'SevenWeekAfterProspectCreationFollowup')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Seven Week After Prospect Creation Followup' ,'SevenWeekAfterProspectCreationFollowup' ,'Seven Week After Prospect Creation Followup' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Seven Week After Prospect Creation Followup'
		,[NotificationTypeNameAlias] = 'SevenWeekAfterProspectCreationFollowup'
		,[Description] = 'Seven Week After Prospect Creation Followup'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'SevenWeekAfterProspectCreationFollowup'
end
