USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('EnableDynamicSlot', 'Enable/Disable Dynamic Slot', 'False', 'Admin', 'Varchar', 1, '', getdate(), getdate())


