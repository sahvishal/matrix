USE [$(dbname)]
GO

ALTER TABLE TblCustomerProfile
ADD ActivityId BIGINT NULL
GO

ALTER TABLE TblCustomerProfile
ADD CONSTRAINT FK_TblCustomerProfile_TblLookup_ActivityId FOREIGN KEY(ActivityId) REFERENCES TblLookup(LookupId)
GO