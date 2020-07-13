USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD AttachUnreadableTest BIT NOT NULL CONSTRAINT DF_TblAccount_AttachUnreadableTest DEFAULT 0
		
GO

 
 
 