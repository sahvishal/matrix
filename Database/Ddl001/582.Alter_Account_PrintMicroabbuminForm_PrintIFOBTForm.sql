USE [$(dbname)]
GO

Alter Table TblAccount Add PrintMicroalbuminForm bit NOT NULL CONSTRAINT DF_TblAccount_PrintMicroalbuminForm DEFAULT 0

Alter Table TblAccount Add PrintIFOBTForm bit NOT NULL CONSTRAINT DF_TblAccount_PrintIFOBTForm DEFAULT 0
Go