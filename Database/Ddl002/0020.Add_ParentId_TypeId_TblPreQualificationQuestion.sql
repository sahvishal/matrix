USE [$(dbname)]
GO

ALTER TABLE TblPreQualificationQuestion
ADD ParentId BIGINT NULL
   ,TypeId BIGINT NULL 

ALTER TABLE TblPreQualificationQuestion
ADD CONSTRAINT FK_TblPreQualificationQuestion_TblLookup_TypeId	FOREIGN KEY (TypeId) REFERENCES TblLookup(LookupId)




