USE [$(dbName)]
GO

Update TblEvents set AllowNonMammoPatients=1
Go


ALTER TABLE TblEvents
Alter column AllowNonMammoPatients  bit  Not NULL 
go

ALTER TABLE TblEvents ADD CONSTRAINT DF_TblEvents_AllowNonMammoPatients DEFAULT 1 FOR AllowNonMammoPatients
Go