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
values('PasswordExpirationDays','PasswordExpirationDays',60,NUll,NUll,'Admin','integer',1,'',GETDATE(),GETDATE())

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
values('PreviousPasswordNonRepetitionCount','PreviousPasswordNonRepetitionCount',3,NUll,NUll,'Admin','integer',1,'',GETDATE(),GETDATE())

GO