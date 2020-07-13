USE [$(dbname)]
GO

ALTER TABLE TblEventCustomerDiagnosis
ADD IsIcd10 BIT NOT NULL CONSTRAINT DF_TblEventCustomerDiagnosis_IsIcd10 DEFAULT 0
GO