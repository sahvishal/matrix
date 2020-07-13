USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD AttachGiftCard BIT NOT NULL CONSTRAINT DF_TblAccount_AttachGiftCard DEFAULT 0
		
GO

ALTER TABLE [dbo].[TblAccount]  
		ADD GiftCardAmount decimal(10, 2) NULL 
		
GO
