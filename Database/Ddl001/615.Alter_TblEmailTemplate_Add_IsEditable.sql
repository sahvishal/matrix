USE [$(dbname)]
GO

ALTER TABLE TblEmailTemplate
ADD [IsEditable] BIT NOT NULL CONSTRAINT DF_TblEmailTemplate_IsEditable DEFAULT(1)
GO