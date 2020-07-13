USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD PrintLoincLabData BIT NOT NULL CONSTRAINT DF_TblAccount_PrintLoincLabData DEFAULT 0
GO