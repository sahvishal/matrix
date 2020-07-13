USE [$(dbName)]
Go

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblContacts_TblRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblContacts]'))
ALTER TABLE [dbo].[TblContacts] DROP CONSTRAINT [FK_TblContacts_TblRole]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblContacts_TblRole1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblContacts]'))
ALTER TABLE [dbo].[TblContacts] DROP CONSTRAINT [FK_TblContacts_TblRole1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerProfile_TblRole1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerProfile]'))
ALTER TABLE [dbo].[TblCustomerProfile] DROP CONSTRAINT [FK_TblCustomerProfile_TblRole1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblRole_TblHostFacilityRanking]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHostFacilityRanking]'))
ALTER TABLE [dbo].[TblHostFacilityRanking] DROP CONSTRAINT [FK_TblRole_TblHostFacilityRanking]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblUser_TblRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblUser]'))
ALTER TABLE [dbo].[TblUser] DROP CONSTRAINT [FK_TblUser_TblRole]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblOrganizationRoleUser_TblRole1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblOrganizationRoleUser]'))
ALTER TABLE [dbo].[TblOrganizationRoleUser] DROP CONSTRAINT [FK_TblOrganizationRoleUser_TblRole1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblRoleAccessControlObject_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblRoleAccessControlObject]'))
ALTER TABLE [dbo].[TblRoleAccessControlObject] DROP CONSTRAINT [FK_TblRoleAccessControlObject_Role]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblRolePermisibleAccessControlObject_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblRolePermisibleAccessControlObject]'))
ALTER TABLE [dbo].[TblRolePermisibleAccessControlObject] DROP CONSTRAINT [FK_TblRolePermisibleAccessControlObject_Role]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblRoleScopeOption_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblRoleScopeOption]'))
ALTER TABLE [dbo].[TblRoleScopeOption] DROP CONSTRAINT [FK_TblRoleScopeOption_Role]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblRole_TblOrganizationType1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblRole]'))
ALTER TABLE [dbo].[TblRole] DROP CONSTRAINT [FK_TblRole_TblOrganizationType1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblRole_TblRole1_ParentId]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblRole]'))
ALTER TABLE [dbo].[TblRole] DROP CONSTRAINT [FK_TblRole_TblRole1_ParentId]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblRole]') AND type in (N'U'))
DROP TABLE [dbo].[TblRole]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblRole](
	[RoleID] [bigint] NOT NULL IDENTITY(1, 1),
	[OrganizationTypeID] [bigint] NULL,
	[Name] [varchar](512) NOT NULL,
	[Alias] [varchar](512) NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Description] [varchar](500) NULL,
	[DefaultPage] [varchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[ShellType] [varchar](500) NULL,
	[ParentId] [bigint] NULL,
	[IsSystemRole] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_TblRole] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_TblRole] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblRole]  WITH CHECK ADD  CONSTRAINT [FK_TblRole_TblOrganizationType1] FOREIGN KEY([OrganizationTypeID])
REFERENCES [dbo].[TblOrganizationType] ([OrganizationTypeID])
GO

ALTER TABLE [dbo].[TblRole] CHECK CONSTRAINT [FK_TblRole_TblOrganizationType1]
GO

ALTER TABLE [dbo].[TblRole]  WITH CHECK ADD  CONSTRAINT [FK_TblRole_TblRole1_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblRole] CHECK CONSTRAINT [FK_TblRole_TblRole1_ParentId]
GO

SET IDENTITY_INSERT TBLRole ON

Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(1, 1, 'Administrator', 'FranchisorAdmin', '2007-02-11 00:00:00.000', '2007-02-11 00:00:00.000', 'Test', 'App/Franchisor/Dashboard.aspx', 1, 'Franchisor', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(2, 2, 'Manager', 'FranchiseeAdmin', '2007-06-11 00:00:00.000', '2007-06-11 00:00:00.000', '', 'App/Franchisee/Dashboard.aspx', 1, 'Franchisee', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(3, 3, 'Call Center Manager', 'CallCenterManager', '2007-12-12 00:00:00.000', '2007-12-12 00:00:00.000', '', 'App/CallCenter/CallCenterManagerDashBoard.aspx', 1, 'CallCenter', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(4, 4, 'Medical Vendor Administrator', 'MedicalVendorAdmin', '2007-12-12 00:00:00.000', '2007-12-12 00:00:00.000', '', 'App/MedicalVendor/MVDashboard.aspx', 1, 'MedicalVendor', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(5, 4, 'Physician', 'MedicalVendorUser', '2007-12-12 00:00:00.000', '2007-12-12 00:00:00.000', '', 'App/MedicalVendor/MVUserDashboard.aspx', 1, 'MedicalVendor', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(6, 2, 'Operation Manager', 'OperationManager', '2007-02-12 00:00:00.000', '2007-02-12 00:00:00.000', '', 'App/CallCenter/CallCenterAdminDasboard.aspx', 1, 'CallCenter', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(7, 2, 'Coordinator', 'SalesRep', '2007-02-12 00:00:00.000', '2007-02-12 00:00:00.000', '', 'App/Franchisee/SalesRep/Dashboard.aspx', 1, 'Franchisee', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(8, 2, 'Technician', 'Technician', '2007-10-12 00:00:00.000', '2007-10-12 00:00:00.000', 'Tech', 'App/Franchisee/Technician/HomePage.aspx', 1, 'Franchisee', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(9, 1, 'Customer', 'Customer', '2007-12-18 00:00:00.000', '2007-12-18 00:00:00.000', 'Customer', 'App/Customer/HomePage.aspx', 1, 'Customer', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(10, 3, 'Call Center Agent', 'CallCenterRep', '2007-12-12 00:00:00.000', '2007-12-12 00:00:00.000', '', 'App/CallCenter/CallCenterRep/CallCenterRepDashBoard.aspx', 1, 'CallCenter', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(11, 2, 'Advocate Manager', 'Advocate Manager', '2007-12-12 00:00:00.000', '2007-12-12 00:00:00.000', '', 'App/MarketingPartner/AdvocateManager/Dashboard.aspx', 1, 'Franchisor', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(12, 2, 'Advocate Sales Manager', 'AdvocateSalesManager', '2009-03-06 03:51:42.290', '2009-03-06 03:51:42.290', 'Sales Manager for Franchisee', 'App/MarketingPartner/AdvocateSalesManager/Dashboard.aspx', 1, 'Franchisee', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(13, 6, 'Print Vendor Administrator', 'PrintVendorAdmin', '2009-03-06 04:24:46.180', '2009-03-06 04:24:46.180', 'Print Vendor', 'App/PrintVendor/Dashboard.aspx', 1, 'PrintVendor', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(14, 4, 'Care Coordinator', 'HospitalPartnerCoordinator', '2011-09-21 05:41:55.510', '2011-09-21 05:41:55.510', 'Hospital Partner Coordinator', '/Users/Dashboard/HospitalPartnerCoordinator', 1, 'MedicalVendor', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(15, 5, 'Account Coordinator', 'CorporateAccountCoordinator', '2011-11-08 05:29:47.000', '2011-11-08 05:29:47.000', 'Role for Corporate Account Coordinator', '/Users/Dashboard/CorporateAccountCoordinator', 1, 'CorporateAccountCoordinator', NULL, 1)


Insert into TBLRole (RoleId, OrganizationTypeID, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType, ParentId, IsSystemRole) VALUES
(16, 8, 'Hospital Facility Coordinator', 'HospitalFacilityCoordinator', '2014-01-10 03:40:09.960', '2014-01-10 03:40:09.960', 'Hospital Facility Coordinator', '/Users/Dashboard/HospitalFacilityCoordinator', 1, 'HospitalFacility', NULL, 1)


SET IDENTITY_INSERT TBLRole OFF


ALTER TABLE [dbo].[TblContacts]  WITH CHECK ADD  CONSTRAINT [FK_TblContacts_TblRole] FOREIGN KEY([AddedRoleID])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblContacts] CHECK CONSTRAINT [FK_TblContacts_TblRole]
GO


ALTER TABLE [dbo].[TblContacts]  WITH CHECK ADD  CONSTRAINT [FK_TblContacts_TblRole1] FOREIGN KEY([ModifiedRoleID])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblContacts] CHECK CONSTRAINT [FK_TblContacts_TblRole1]
GO


ALTER TABLE [dbo].[TblCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerProfile_TblRole1] FOREIGN KEY([AddedByRoleID])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblCustomerProfile] CHECK CONSTRAINT [FK_TblCustomerProfile_TblRole1]
GO


ALTER TABLE [dbo].[TblHostFacilityRanking]  WITH CHECK ADD  CONSTRAINT [FK_TblRole_TblHostFacilityRanking] FOREIGN KEY([RankedByRole])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblHostFacilityRanking] CHECK CONSTRAINT [FK_TblRole_TblHostFacilityRanking]
GO


ALTER TABLE [dbo].[TblUser]  WITH CHECK ADD  CONSTRAINT [FK_TblUser_TblRole] FOREIGN KEY([DefaultRoleID])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblUser] CHECK CONSTRAINT [FK_TblUser_TblRole]
GO


ALTER TABLE [dbo].[TblOrganizationRoleUser]  WITH CHECK ADD  CONSTRAINT [FK_TblOrganizationRoleUser_TblRole1] FOREIGN KEY([RoleID])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblOrganizationRoleUser] CHECK CONSTRAINT [FK_TblOrganizationRoleUser_TblRole1]
GO



ALTER TABLE [dbo].[TblRoleAccessControlObject]  WITH CHECK ADD  CONSTRAINT [FK_TblRoleAccessControlObject_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblRoleAccessControlObject] CHECK CONSTRAINT [FK_TblRoleAccessControlObject_Role]
GO


ALTER TABLE [dbo].[TblRolePermisibleAccessControlObject]  WITH CHECK ADD  CONSTRAINT [FK_TblRolePermisibleAccessControlObject_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblRolePermisibleAccessControlObject] CHECK CONSTRAINT [FK_TblRolePermisibleAccessControlObject_Role]
GO


ALTER TABLE [dbo].[TblRoleScopeOption]  WITH CHECK ADD  CONSTRAINT [FK_TblRoleScopeOption_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[TblRole] ([RoleID])
GO

ALTER TABLE [dbo].[TblRoleScopeOption] CHECK CONSTRAINT [FK_TblRoleScopeOption_Role]
GO