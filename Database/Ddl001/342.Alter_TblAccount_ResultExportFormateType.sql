
USE [$(dbName)]
GO 

ALTER TABLE TblAccount ADD ResultFormatTypeId bigint NULL
GO

ALTER TABLE TblAccount ADD CONSTRAINT FK_TblAccount_TblLookup_ResultFormat FOREIGN KEY (ResultFormatTypeId) REFERENCES dbo.TblLookup (LookupId) 
	
GO
