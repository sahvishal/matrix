USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCustomerProfile_InsuranceId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblCustomerProfile] DROP CONSTRAINT [DF_TblCustomerProfile_InsuranceId]
END

GO


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCustomerProfile_EmployeeId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblCustomerProfile] DROP CONSTRAINT [DF_TblCustomerProfile_EmployeeId]
END

GO