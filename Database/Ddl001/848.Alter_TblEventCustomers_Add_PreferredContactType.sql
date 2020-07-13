USE [$(dbname)]
GO

ALTER TABLE TblEventCustomers
ADD PreferredContactType BIGINT NULL,
	CONSTRAINT FK_TblEventCustomers_TblLookup_PreferredContactType FOREIGN KEY([PreferredContactType]) REFERENCES [TblLookup]([LookupId])
GO
