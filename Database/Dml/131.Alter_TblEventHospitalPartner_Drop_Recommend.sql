USE [$(dbName)]
Go

Update TblEvents set RecommendPackage=1 where EventID in (select EventID from TblEventHospitalPartner where RecommendPackage=1)
GO

Update TblEvents  set RecommendPackage=1  where EventID in(select EventID from TblEvents Where  EventID not in (select EventID from TblEventAccount) and EventId not in (select EventID from TblEventHospitalPartner))
GO

ALTER TABLE dbo.TblEventHospitalPartner
	DROP CONSTRAINT DF_TblEventHospitalPartner_RecommendPackage
GO

ALTER TABLE dbo.TblEventHospitalPartner
	DROP COLUMN RecommendPackage
GO

