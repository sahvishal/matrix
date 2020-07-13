USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoArchiveTemp_TblCustomerHealthQuestions]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoArchiveTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblCustomerHealthQuestions]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoArchiveTemp_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoArchiveTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblCustomerProfile]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoArchiveTemp_TblEventCustomers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoArchiveTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblEventCustomers]
GO


/****** Object:  Table [dbo].[TblCustomerHealthInfoArchiveTemp]    Script Date: 09/05/2016 13:15:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoArchiveTemp]') AND type in (N'U'))
DROP TABLE [dbo].[TblCustomerHealthInfoArchiveTemp]
GO



IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoTemp_TblCustomerHealthQuestions]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblCustomerHealthQuestions]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoTemp_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblCustomerProfile]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoTemp_TblEventCustomers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblEventCustomers]
GO


/****** Object:  Table [dbo].[TblCustomerHealthInfoTemp]    Script Date: 09/05/2016 13:15:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoTemp]') AND type in (N'U'))
DROP TABLE [dbo].[TblCustomerHealthInfoTemp]
GO


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblEventMarketingMaterial_tblAFCampaign]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblEventMarketingMaterial]'))
ALTER TABLE [dbo].[tblEventMarketingMaterial] DROP CONSTRAINT [FK_tblEventMarketingMaterial_tblAFCampaign]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblEventMarketingMaterial_tblAFMarketingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblEventMarketingMaterial]'))
ALTER TABLE [dbo].[tblEventMarketingMaterial] DROP CONSTRAINT [FK_tblEventMarketingMaterial_tblAFMarketingMaterial]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblEventMarketingMaterial_tblEventMarketingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblEventMarketingMaterial]'))
ALTER TABLE [dbo].[tblEventMarketingMaterial] DROP CONSTRAINT [FK_tblEventMarketingMaterial_tblEventMarketingMaterial]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblEventMarketingMaterial_TblOrganizationRoleUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblEventMarketingMaterial]'))
ALTER TABLE [dbo].[tblEventMarketingMaterial] DROP CONSTRAINT [FK_tblEventMarketingMaterial_TblOrganizationRoleUser]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblEventMarketingMaterial_TblOrganizationRoleUser1]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblEventMarketingMaterial]'))
ALTER TABLE [dbo].[tblEventMarketingMaterial] DROP CONSTRAINT [FK_tblEventMarketingMaterial_TblOrganizationRoleUser1]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tblEventMarketingMaterial_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tblEventMarketingMaterial] DROP CONSTRAINT [DF_tblEventMarketingMaterial_IsActive]
END

GO


/****** Object:  Table [dbo].[tblEventMarketingMaterial]    Script Date: 09/05/2016 13:17:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEventMarketingMaterial]') AND type in (N'U'))
DROP TABLE [dbo].[tblEventMarketingMaterial]
GO
