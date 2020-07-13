USE [$(dbName)]
Go 

ALTER TABLE dbo.TblHAFTemplate ADD Category bigint NULL
GO

ALTER TABLE dbo.TblHAFTemplate ADD CONSTRAINT FK_TblHAFTemplate_tblLookup_Category FOREIGN KEY
								( Category) REFERENCES dbo.TblLookup (LookupId)
	
GO

Alter TABLE TblHAFTemplate ALTER COLUMN [Type] bigint NULL
Go
