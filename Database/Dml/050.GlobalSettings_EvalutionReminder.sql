USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('SendEmptyQueueEvaluationReminder', 'Send Evaluation Reminder mail for Empty Queue', 'True', 'Admin', 'Varchar', 1, '', getdate(), getdate()) -- True - HF, False - PHS
