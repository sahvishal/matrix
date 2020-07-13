USE [$(dbname)]
GO

ALTER TABLE TblEventCustomers
ADD LeftWithoutScreeningNotesId BIGINT NULL
GO

ALTER TABLE TblEventCustomers
ADD CONSTRAINT FK_TblEventCustomers_TblCustomerRegistrationNotes FOREIGN KEY (LeftWithoutScreeningNotesId) REFERENCES TblCustomerRegistrationNotes(CustomerRegistrationNotesID)
GO