USE [$(dbname)]
GO

ALTER TABLE TblCalls
ADD DialerType BIGINT NULL,
	CONSTRAINT FK_TblCalls_TblLookup_DialerType FOREIGN KEY([DialerType]) REFERENCES [TblLookup]([LookupId])
GO