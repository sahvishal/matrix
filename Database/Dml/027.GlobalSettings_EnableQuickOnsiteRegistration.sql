USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('EnableQuickOnsiteRegistration', 'Enable Quick Onsite Registration', 'false', 'Admin', 'Varchar', 1, '', getdate(), getdate())
