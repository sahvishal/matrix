
USE [$(dbName)]
GO

ALTER TABLE dbo.TblTempCart ADD
	HighBloodPressure bigint NULL,
	Smoker bigint NULL,
	HeartDisease bigint NULL,
	Diabetic bigint NULL,
	ChestPain bigint NULL
GO
ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_HighBloodPressure_Lookup FOREIGN KEY
	( 	HighBloodPressure ) REFERENCES dbo.TblLookup
	(	LookupId	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_Smoker_Lookup FOREIGN KEY
	( 	Smoker	) REFERENCES dbo.TblLookup
	(	LookupId	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_HearthDisease_Lookup FOREIGN KEY	( 	HeartDisease	) REFERENCES dbo.TblLookup	(	LookupId	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_Diabetic_Lookup FOREIGN KEY
	(	Diabetic	) REFERENCES dbo.TblLookup	(	LookupId	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TblTempCart ADD CONSTRAINT
	FK_TblTempCart_ChestPain_Lookup FOREIGN KEY
	( 	ChestPain	) REFERENCES dbo.TblLookup	(	LookupId	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

