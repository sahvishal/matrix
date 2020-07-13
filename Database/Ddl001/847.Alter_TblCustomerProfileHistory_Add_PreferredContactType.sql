USE [$(dbname)]
GO

ALTER TABLE TblCustomerProfileHistory
ADD PreferredContactType BIGINT NULL,
	CONSTRAINT FK_TblCustomerProfileHistory_TblLookup_PreferredContactType FOREIGN KEY([PreferredContactType]) REFERENCES [TblLookup]([LookupId])
GO
