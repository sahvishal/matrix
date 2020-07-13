USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD RestrictHealthPlanData BIT not null 
CONSTRAINT DF_TblAccount_RestrictHealthPlanData
DEFAULT 0

GO

