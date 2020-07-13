
USE [$(dbName)]
Go

Alter Table TblEvents Add IsDynamicScheduling bit not null CONSTRAINT DF_TblEvents_IsDynamicScheduling DEFAULT 0

