Use [$(dbname)]
go



	Insert Into TblPreApprovedPackageTemp ([CustomerId],[PackageId],[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId],[IsActive])
		Select CustomerId,PackageId,DateCreated,DateModified,CreatedByOrgRoleUserId,ModifiedByOrgRoleUserId,IsActive from TblPreApprovedPackage

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedPackage_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedPackage]'))
		ALTER TABLE [dbo].[TblPreApprovedPackage] DROP CONSTRAINT [FK_TblPreApprovedPackage_TblCustomerProfile]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedPackage_TblOrganizationRoleUser_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedPackage]'))
		ALTER TABLE [dbo].[TblPreApprovedPackage] DROP CONSTRAINT [FK_TblPreApprovedPackage_TblOrganizationRoleUser_CreatedBy]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedPackage_TblOrganizationRoleUser_ModifiedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedPackage]'))
		ALTER TABLE [dbo].[TblPreApprovedPackage] DROP CONSTRAINT [FK_TblPreApprovedPackage_TblOrganizationRoleUser_ModifiedBy]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedPackage_TblPackage]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedPackage]'))
		ALTER TABLE [dbo].[TblPreApprovedPackage] DROP CONSTRAINT [FK_TblPreApprovedPackage_TblPackage]
	GO

	/****** Object:  Table [dbo].[TblPreApprovedTest]    Script Date: 04/14/2014 18:04:34 ******/
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPreApprovedPackage]') AND type in (N'U'))
		DROP TABLE [dbo].[TblPreApprovedPackage]
	GO



CREATE TABLE [dbo].[TblPreApprovedPackage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[PackageId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,	
	[DateEnd] [dateTime] null,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,	
	[IsActive] [bit] NOT NULL,
	CONSTRAINT PK_TblPreApprovedPackage PRIMARY KEY ([Id]) 
)

Go

	Insert Into TblPreApprovedPackage  ([CustomerId],[PackageId],[DateCreated],[CreatedByOrgRoleUserId],[IsActive])
		Select CustomerId,PackageId,DateCreated,CreatedByOrgRoleUserId,IsActive from TblPreApprovedPackageTemp


		
ALTER TABLE [dbo].[TblPreApprovedPackage]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedPackage_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblPreApprovedPackage] CHECK CONSTRAINT [FK_TblPreApprovedPackage_TblCustomerProfile]
GO

ALTER TABLE [dbo].[TblPreApprovedPackage]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedPackage_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreApprovedPackage] CHECK CONSTRAINT [FK_TblPreApprovedPackage_TblOrganizationRoleUser_CreatedBy]
GO

ALTER TABLE [dbo].[TblPreApprovedPackage]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedPackage_TblPackage] FOREIGN KEY([PackageID])
REFERENCES [dbo].[TblPackage] ([PackageID])
GO

ALTER TABLE [dbo].[TblPreApprovedPackage] CHECK CONSTRAINT [FK_TblPreApprovedPackage_TblPackage]
GO