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
values('AlertBeforePasswordExpirationInDays','AlertBeforePasswordExpirationInDays','3',NUll,NUll,'Admin','integer',1,'',GETDATE(),GETDATE())

GO