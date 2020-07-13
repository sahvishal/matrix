USE [$(dbName)]
Go
 
Alter table TblCurrentMedication Add   IsPrescribed bit NOT NULL CONSTRAINT DF_TblCurrentMedication_IsPrescribed DEFAULT 0
Alter table TblCurrentMedication Add   IsOtc bit NOT NULL CONSTRAINT DF_TblCurrentMedication_IsOtc DEFAULT 0