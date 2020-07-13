USE [$(dbname)]
GO

ALTER TABLE TblCustomerProfile
ADD PreferredContactType BIGINT NULL,
	CONSTRAINT FK_TblCustomerProfile_TblLookup_PreferredContactType FOREIGN KEY([PreferredContactType]) REFERENCES [TblLookup]([LookupId])
GO
