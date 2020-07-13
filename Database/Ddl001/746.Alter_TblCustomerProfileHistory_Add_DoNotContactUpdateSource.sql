USE [$(dbname)]
GO

ALTER TABLE TblCustomerProfileHistory
ADD DoNotContactUpdateSource BIGINT NULL,
	CONSTRAINT FK_TblCustomerProfileHistory_TblLookup_DoNotContactUpdateSource FOREIGN KEY ([DoNotContactUpdateSource]) REFERENCES [TblLookup]([LookupId])

GO