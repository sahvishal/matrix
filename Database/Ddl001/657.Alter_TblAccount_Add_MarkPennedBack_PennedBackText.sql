USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD MarkPennedBack BIT NOT NULL CONSTRAINT DF_TblAccount_PenBackResult DEFAULT 0,
	PennedBackText VARCHAR(512) NULL
GO