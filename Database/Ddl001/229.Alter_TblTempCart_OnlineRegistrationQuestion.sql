
USE [$(dbName)]
GO

ALTER TABLE dbo.TblTempCart ADD
	DiagnosedHeartProblem bigint NULL
	
GO
ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_DiagnosedHeartProblem_Lookup FOREIGN KEY
	( 	DiagnosedHeartProblem ) REFERENCES dbo.TblLookup
	(	LookupId	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 
	
GO