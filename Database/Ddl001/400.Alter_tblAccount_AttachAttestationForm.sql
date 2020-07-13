USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD AttachAttestationForm BIT NOT NULL CONSTRAINT DF_TblAccount_AttachAttestationForm DEFAULT 0
		
GO