USE [$(dbname)]
GO

ALTER TABLE TblCustomerRegistrationNotes
ADD ReasonId BIGINT NULL
GO

ALTER TABLE TblCustomerRegistrationNotes
ADD CONSTRAINT FK_TblCustomerRegistrationNotes_TblLookup FOREIGN KEY (ReasonId) REFERENCES TblLookup (LookupId)
GO