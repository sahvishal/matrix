USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('LunchStartTime', 'Lunch start time', '12:00 PM', 'Admin', 'Varchar', 1, '', getdate(), getdate()) 
