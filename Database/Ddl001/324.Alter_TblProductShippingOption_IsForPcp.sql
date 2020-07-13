USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblProductShippingOption]  
		ADD IsForPcp BIT NOT NULL CONSTRAINT DF_TblProductShippingOption_IsForPcp DEFAULT 0 
		
GO