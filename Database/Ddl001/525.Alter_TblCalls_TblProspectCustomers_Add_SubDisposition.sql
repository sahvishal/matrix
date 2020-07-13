USE [$(dbname)]
GO

ALTER TABLE TblProspectCustomer
ADD SubDispositionId BIGINT NULL CONSTRAINT FK_TblProspectCustomer_TblLookup_SubDispositionId FOREIGN KEY (SubDispositionId) REFERENCES [TblLookup](LookupId)
GO

ALTER TABLE TblCalls
ADD SubDispositionId BIGINT NULL CONSTRAINT FK_TblCalls_TblLookup_SubDispositionId FOREIGN KEY (SubDispositionId) REFERENCES [TblLookup](LookupId)
GO