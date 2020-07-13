USE [$(dbName)]
Go

ALTER TABLE dbo.TblTempCart ADD
	SkipPreQualificationQuestion bit NOT NULL CONSTRAINT DF_TblTempCart_SkipPreQualificationQuestion DEFAULT 0,
	AgeOverPreQualificationQuestion bigInt Null 
	
GO

ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_AgeOverPreQualificationQuestion_Lookup FOREIGN KEY
	( 	AgeOverPreQualificationQuestion ) REFERENCES dbo.TblLookup
	(	LookupId	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 
	
GO