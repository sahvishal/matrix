
USE [$(dbName)]
Go

Alter Table TblCustomerProfile Add UserDefined1 varchar(1000) null

--For Phs only
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TblCustomerProfile_UserDefined1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerProfile]'))
--Begin
--	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCustomerProfile_UserDefined1]') AND type = 'D')
--	BEGIN
--	ALTER TABLE [dbo].[TblCustomerProfile] ADD CONSTRAINT [DF_TblCustomerProfile_UserDefined1] DEFAULT ('Not Available') FOR [UserDefined1]
--	END
--End
--GO
