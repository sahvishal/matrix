USE [$(dbname)]
GO

ALTER TABLE TblCustomerProfile
ADD DoNotContactUpdateSource BIGINT NULL,
	CONSTRAINT FK_TblCustomerProfile_TblLookup_DoNotContactUpdateSource FOREIGN KEY ([DoNotContactUpdateSource]) REFERENCES [TblLookup]([LookupId])

GO

ALTER TABLE TblCallQueueCustomer
ADD DoNotContactUpdateSource BIGINT NULL,
	CONSTRAINT FK_TblCallQueueCustomer_TblLookup_DoNotContactUpdateSource FOREIGN KEY ([DoNotContactUpdateSource]) REFERENCES [TblLookup]([LookupId])

GO