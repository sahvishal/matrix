USE [$(dbname)]
GO

ALTER Table TblCorporateUpload
ADD SourceId BIGINT NULL
GO 

ALTER TABLE TblCorporateUpload
ADD CONSTRAINT FK_TblCorporateUpload_TblLookup_SourceId
FOREIGN KEY (SourceId)
REFERENCES [TblLookup](LookupId)
GO
