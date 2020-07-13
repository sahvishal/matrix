USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('ShowBasicBiometric', 'Show Basic Biometric Section', 'true', 'Admin', 'Varchar', 1, '', getdate(), getdate())
