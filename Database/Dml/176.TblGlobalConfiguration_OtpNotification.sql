USE [$(dbName)]
Go


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
values('OtpNotificationMediumEmail','OtpNotificationMediumEmail','True',NUll,NUll,'Admin','Varchar',1,'',GETDATE(),GETDATE())

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
values('OtpNotificationMediumSms','OtpNotificationMediumSms','True',NUll,NUll,'Admin','Varchar',1,'',GETDATE(),GETDATE())


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
values('OtpExpirationMinutes','OtpExpirationMinutes','60',NUll,NUll,'Admin','integer',1,'',GETDATE(),GETDATE())

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
values('OtpMisMatchAttemptCount','OtpMisMatchAttemptCount','3',NUll,NUll,'Admin','integer',1,'',GETDATE(),GETDATE())

GO