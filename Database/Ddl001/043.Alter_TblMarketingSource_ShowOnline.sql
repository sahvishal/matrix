
USE [$(dbName)]
Go

Alter Table TblMarketingSource Add ShowOnline bit not null CONSTRAINT DF_TblMarketingSource_ShowOnline DEFAULT 0