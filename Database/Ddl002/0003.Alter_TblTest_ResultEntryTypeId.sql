USE [$(dbname)]
GO

ALTER TABLE TblTest Add ResultEntryTypeId BIGINT NULL 

ALTER TABLE TblTest
	ADD CONSTRAINT FK_TblTest_TblLookup_ResultEntryTypeId FOREIGN KEY (ResultEntryTypeId) REFERENCES TblLookup(LookupId)

ALTER TABLE TblEventTest Add ResultEntryTypeId BIGINT NULL 

ALTER TABLE TblEventTest
	ADD CONSTRAINT FK_TblEventTest_TblLookup_ResultEntryTypeId	FOREIGN KEY (ResultEntryTypeId) REFERENCES TblLookup(LookupId)
