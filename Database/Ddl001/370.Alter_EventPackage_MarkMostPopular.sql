USE [$(dbName)]
GO

ALTER TABLE TblEventPackageDetails  
		ADD MostPopular BIT NOT NULL CONSTRAINT DF_TblEventPackageDetails_MostPopular DEFAULT 0		
GO

ALTER TABLE TblEventPackageDetails  
		ADD BestValue BIT NOT NULL CONSTRAINT DF_TblEventPackageDetails_BestValue DEFAULT 0		
GO