USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('PackageSelectionInfo', 'Package Selection Info', 'True', 'Admin', 'Varchar', 1, '', getdate(), getdate()) 
