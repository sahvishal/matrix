USE [$(dbName)]
Go 

ALTER TABLE dbo.TblAccount ADD 
	DefaultSelectionBasePackage bit CONSTRAINT [DF_TblAccount_DefaultSelectionBasePackage]  DEFAULT ((0)) NOT NULL 
GO
 
