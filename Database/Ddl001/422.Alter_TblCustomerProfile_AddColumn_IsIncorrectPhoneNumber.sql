
USE [$(dbName)]
Go


ALTER TABLE TblCustomerProfile Add IsIncorrectPhoneNumber bit not null  CONSTRAINT DF_TblCustomerProfile_IsIncorrectPhoneNumber DEFAULT 0
GO



