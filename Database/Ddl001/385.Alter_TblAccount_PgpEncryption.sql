USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD EnablePgpEncryption BIT NOT NULL CONSTRAINT DF_TblAccount_EnablePgpEncryption DEFAULT 0,
		PublicKeyFileId bigint NULL
		
GO