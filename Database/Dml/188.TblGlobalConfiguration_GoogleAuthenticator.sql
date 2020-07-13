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
values('OtpByGoogleAuthenticator','OtpByGoogleAuthenticator','True',NUll,NUll,'Admin','Bit',1,'',GETDATE(),GETDATE())

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
values('AllowSafeComputerRemember','AllowSafeComputerRemember','True',NUll,NUll,'Admin','Bit',1,'',GETDATE(),GETDATE())


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
values('SafeDeviceExpiryDays','SafeDeviceExpiryDays','60',NUll,NUll,'Admin','integer',1,'',GETDATE(),GETDATE())

GO

 

update [TblUserLogin]
set [LastPasswordChangeDate] = DateModified
 
GO

Alter table [TblUserLogin]
Alter Column [LastPasswordChangeDate] [datetime]  Not NULL    
 
GO