USE [$(dbname)]
GO

ALTER TABLE TblEventCustomers
ADD IsForRetest BIT NOT NULL CONSTRAINT DF_TblEventCustomers_IsForRetest DEFAULT (0)

GO