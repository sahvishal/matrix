USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD PrintAceForm BIT NOT NULL CONSTRAINT DF_TblAccount_PrintAceForm DEFAULT(0),
	PrintMipForm BIT NOT NULL CONSTRAINT DF_TblAccount_PrintMipForm DEFAULT(0)
GO