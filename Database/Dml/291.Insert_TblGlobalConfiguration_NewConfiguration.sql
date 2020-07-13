USE [$(dbName)]
GO

Insert into TblGlobalConfiguration (Name,[Description],Value,SettingGroupName,DataType,IsActive,Delimiter,DateCreated,DateModified)
values ('EnableVoiceMailNotification','EnableVoiceMailNotification','True','Admin','Varchar',1,'',GETDATE(),getdate())