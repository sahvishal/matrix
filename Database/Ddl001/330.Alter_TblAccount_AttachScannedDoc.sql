USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD AttachScannedDoc BIT NOT NULL CONSTRAINT DF_TblAccount_AttachScannedDoc DEFAULT 0
		
GO

 
 
 