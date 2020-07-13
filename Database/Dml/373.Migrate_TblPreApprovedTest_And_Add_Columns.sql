	Use [$(dbname)]
	go

	Insert Into TblPreApprovedTestTemp ([CustomerId],[TestId],[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId],[IsActive])
		Select CustomerId,TestId,DateCreated,DateModified,CreatedByOrgRoleUserId,ModifiedByOrgRoleUserId,IsActive from TblPreApprovedTest

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedTest_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]'))
		ALTER TABLE [dbo].[TblPreApprovedTest] DROP CONSTRAINT [FK_TblPreApprovedTest_TblCustomerProfile]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedTest_TblOrganizationRoleUser_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]'))
		ALTER TABLE [dbo].[TblPreApprovedTest] DROP CONSTRAINT [FK_TblPreApprovedTest_TblOrganizationRoleUser_CreatedBy]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedTest_TblOrganizationRoleUser_ModifiedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]'))
		ALTER TABLE [dbo].[TblPreApprovedTest] DROP CONSTRAINT [FK_TblPreApprovedTest_TblOrganizationRoleUser_ModifiedBy]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedTest_TblTest]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]'))
		ALTER TABLE [dbo].[TblPreApprovedTest] DROP CONSTRAINT [FK_TblPreApprovedTest_TblTest]
	GO

	/****** Object:  Table [dbo].[TblPreApprovedTest]    Script Date: 04/14/2014 18:04:34 ******/
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]') AND type in (N'U'))
		DROP TABLE [dbo].[TblPreApprovedTest]
	GO

	CREATE TABLE [dbo].[TblPreApprovedTest](
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		[CustomerId] [bigint] NOT NULL,
		[TestId] [bigint] NOT NULL,
		[DateCreated] [datetime] NOT NULL,	
		[DateEnd] [dateTime] null,
		[CreatedByOrgRoleUserId] [bigint] NOT NULL,	
		[IsActive] [bit] NOT NULL,
		CONSTRAINT PK_TblPreApprovedTest PRIMARY KEY ([Id])
	) 

	GO


	Insert Into TblPreApprovedTest ([CustomerId],[TestId],[DateCreated],[CreatedByOrgRoleUserId],[IsActive])
			Select CustomerId, TestId, DateCreated, CreatedByOrgRoleUserId, IsActive from TblPreApprovedTestTemp

		
	ALTER TABLE [dbo].[TblPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedTest_TblCustomerProfile] FOREIGN KEY([CustomerId])
	REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
	GO

	ALTER TABLE [dbo].[TblPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedTest_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
	REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
	GO

	ALTER TABLE [dbo].[TblPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedTest_TblTest] FOREIGN KEY([TestId])
	REFERENCES [dbo].[TblTest] ([TestID])
	GO

