USE [$(dbName)]
Go

Alter Table TblCustomerProfile Add EnableVoiceMail BIT NOT NULL CONSTRAINT DF_TblCustomerProfile_EnableVoiceMail DEFAULT 0