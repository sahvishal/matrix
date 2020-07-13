USE [$(dbname)]
GO

Alter Table  TblCustomerProfile 
Drop constraint FK_TblCustomerProfile_TblLookup_ActivityId
GO

ALTER TABLE TblCustomerProfile
ADD CONSTRAINT FK_TblCustomerProfile_TblActivityType_ActivityId
FOREIGN KEY (ActivityId) REFERENCES TblActivityType(Id)

GO