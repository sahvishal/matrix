USE [$(dbName)]
Go 

Alter Table TblCustomerProfile Add IsEligble bit NULL
GO

Alter Table TblCustomerProfile Add LanguageId bigint NULL
GO

ALTER TABLE [dbo].[TblCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerProfile_TblLanguage] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[TblLanguage] ([Id])
GO   

Alter Table TblCustomerProfile Add LabId bigint NULL
GO
 
ALTER TABLE [dbo].[TblCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerProfile_TblLab] FOREIGN KEY([LabId])
REFERENCES [dbo].[TblLab] ([Id])
GO  

 
  
  