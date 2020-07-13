USE [$(dbname)]
GO

ALTER TABLE TblEventCustomers
ADD PatientDetailId BIGINT NULL
GO