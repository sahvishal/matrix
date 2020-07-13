USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('PayLaterOnlineRegistration', 'Pay Later Online Registration', 'true', 'Admin', 'Varchar', 1, '', getdate(), getdate())
