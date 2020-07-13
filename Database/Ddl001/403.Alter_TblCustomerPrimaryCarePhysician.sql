USE [$(dbName)]
Go 

ALTER TABLE [dbo].[TblCustomerPrimaryCarePhysician]
add MailingAddressId bigint NULL CONSTRAINT [FK_TblCustomerPrimarycarePhysician_TblAddress_MailingAddressId] FOREIGN KEY(MailingAddressID) REFERENCES [dbo].[TblAddress] ([AddressID])

GO