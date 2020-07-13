USE [$(dbName)]
Go
INSERT INTO TblNotificationType
           (NotificationTypeName
           ,NotificationTypeNameAlias
           ,Description
           ,DateCreated
           ,DateModified
           ,IsActive
           ,NoOfAttempts
           ,IsServiceEnabled
           ,IsQueuingEnabled
           ,ModifiedByOrgRoleUserId
           ,NotificationMediumId)
     VALUES
           ('AWV Customer Result Fax Notification','AWVCustomerResultFaxNotification','AWVCustomerResultFaxNotification',GETDATE(),GETDATE(),1,1,0,0,1,4)

GO

INSERT into TblGlobalConfiguration
			(Name
           ,Description
           ,Value
           ,RoleTypeID
           ,UserID
           ,SettingGroupName
           ,DataType
           ,IsActive
           ,Delimiter
           ,DateCreated
           ,DateModified)
values('EnableAWVCustomerResultFaxNotification','EnableAWVCustomerResultFaxNotification','False',NUll,NUll,'Admin','Varchar',1,'',GETDATE(),GETDATE())

GO