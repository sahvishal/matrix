USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('IsHipaaEnabled', 'Is Hipaa Signing Process Enabled', 'False', 'Admin', 'Varchar', 1, '', getdate(), getdate()) -- Keep 'true' for HF
