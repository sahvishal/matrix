USE [$(dbname)]
GO

ALTER TABLE TblKynLabValues
ADD BodyFat VARCHAR(50) NULL,
	BoneDensity VARCHAR(50) NULL,
	Psa VARCHAR(50) NULL,
	NonHdlCholestrol VARCHAR(50) NULL,
	Nicotine VARCHAR(50) NULL,
	Cotinine VARCHAR(50) NULL,
	Smoker VARCHAR(50) NULL,
	LdlCholestrol bigint null
GO