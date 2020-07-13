USE [$(dbName)]
Go

INSERT into TblGlobalConfiguration
values('EnableSmsNotification','EnableSmsNotification','True',NUll,NUll,'Admin','Varchar',1,'',GETDATE(),GETDATE())