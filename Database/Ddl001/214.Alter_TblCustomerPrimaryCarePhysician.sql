
USE [$(dbName)]
GO

Alter Table TblCustomerPrimaryCarePhysician Add [PrefixText] [varchar](255) NULL
go

Alter Table TblCustomerPrimaryCarePhysician Add [SuffixText] [varchar](255) NULL
go

Alter Table TblCustomerPrimaryCarePhysician Add [CredentialText] [varchar](255) NULL
go

Alter Table TblCustomerPrimaryCarePhysician Add [PhysicianMasterId] bigint null
go

ALTER TABLE [dbo].[TblCustomerPrimaryCarePhysician]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerPrimaryCarePhysician_TblPhysicianMaster] FOREIGN KEY([PhysicianMasterId])
REFERENCES [dbo].[TblPhysicianMaster] ([PhysicianMasterId])
GO