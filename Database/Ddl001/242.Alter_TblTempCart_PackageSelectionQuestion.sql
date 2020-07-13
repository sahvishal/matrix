USE [$(dbName)]
GO

ALTER TABLE dbo.TblTempCart ADD
	HighCholestrol bigint NULL,
	OverWeight bigint null
	
GO
ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_HighCholestrol_Lookup FOREIGN KEY
	( 	HighCholestrol ) REFERENCES dbo.TblLookup
	(	LookupId	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_OverWeight_Lookup FOREIGN KEY
	( 	OverWeight	) REFERENCES dbo.TblLookup
	(	LookupId	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 
	
GO