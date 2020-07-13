USE [$(dbname)]
GO

ALTER TABLE TblTag
ADD [CallStatus] BIGINT NULL,
	CONSTRAINT FK_TblTag_TblLookup_CallStatus FOREIGN KEY([CallStatus]) REFERENCES [TblLookup]([LookupId])

GO