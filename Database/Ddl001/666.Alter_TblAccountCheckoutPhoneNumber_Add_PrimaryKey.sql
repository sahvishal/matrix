USE [$(dbname)]
GO

ALTER TABLE TblAccountCheckoutPhoneNumber
DROP CONSTRAINT  PK_TblAccountCheckoutPhoneNumber_1

ALTER TABLE TblAccountCheckoutPhoneNumber
ADD ID BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL 