
USE [$(dbName)]
GO


Alter Table TblCustomerProfile Add Tag bigint NULL
GO

ALTER TABLE [dbo].[TblCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerProfile_TblLookup] FOREIGN KEY([Tag])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

Alter Table TblCustomerProfile Add HICN varchar(100) NULL
GO

