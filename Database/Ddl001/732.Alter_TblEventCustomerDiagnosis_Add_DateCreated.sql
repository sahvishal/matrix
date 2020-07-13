USE [$(dbname)]
GO

ALTER TABLE TblEventCustomerDiagnosis
ADD DateCreated DATETIME NULL
GO