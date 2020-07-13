
USE [$(dbName)]
Go

Alter Table TblEvents Add NotifyResultReady bit not null CONSTRAINT DF_TblEvents_NotifyResultReady DEFAULT 1

