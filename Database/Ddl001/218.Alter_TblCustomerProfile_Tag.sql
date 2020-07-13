
USE [$(dbName)]
GO

Alter Table TblCustomerProfile Add Tag1 varchar(255) NULL
GO

Update TblCustomerProfile 
set Tag1 = 'Physician Partner'
where Tag = 170
GO

Update TblCustomerProfile 
set Tag1 = 'Archived Physician Partner'
where Tag = 177
GO

Update TblCustomerProfile 
set Tag1 = 'Rite Aid'
where Tag = 181
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerProfile_TblLookup]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerProfile]'))
ALTER TABLE [dbo].[TblCustomerProfile] DROP CONSTRAINT [FK_TblCustomerProfile_TblLookup]
GO

ALTER TABLE [dbo].[TblCustomerProfile] DROP Column Tag
GO

sp_RENAME 'TblCustomerProfile.Tag1','Tag','COLUMN'
GO