USE [$(dbName)]
Go

ALTER TABLE TblCustomerProfile ADD EnableTexting BIT NOT NULL CONSTRAINT DF_TblCustomerProfile_EnableTexting DEFAULT 0
Go 

ALTER TABLE TblEmailTemplate ADD TemplateType BIGINT NULL 
Go

ALTER TABLE [dbo].[TblEmailTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TblEmailTemplate_TblLookup] FOREIGN KEY([TemplateType])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO


