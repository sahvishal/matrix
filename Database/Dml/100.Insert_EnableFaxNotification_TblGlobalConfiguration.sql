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
values('EnableFaxNotification','EnableFaxNotification','False',NUll,NUll,'Admin','Varchar',1,'',GETDATE(),GETDATE())

