USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('ScreeningReminderNotification', 'Screening Reminder Notification', 'False', 'Admin', 'Varchar', 1, '', getdate(), getdate())
