USE [$(dbname)]
GO

ALTER TABLE TblEventCustomerCriticalQuestion
ADD Note NVARCHAR(MAX) NULL
GO