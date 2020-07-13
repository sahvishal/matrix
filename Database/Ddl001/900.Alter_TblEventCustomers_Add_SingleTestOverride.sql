USE [$(dbname)]
GO

ALTER TABLE TblEventCustomers
ADD SingleTestOverride BIT NOT NULL CONSTRAINT DF_TblEventCustomers_SingleTestOverride DEFAULT(0)

GO