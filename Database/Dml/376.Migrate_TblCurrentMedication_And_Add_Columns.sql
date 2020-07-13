	use [$(dbname)]
	go
	
	Insert Into TblCurrentMedicationTemp (CustomerId,NdcId,DateCreated,DateModified,CreatedByOrgRoleUserId,ModifiedByOrgRoleUserId,IsPrescribed,IsOtc,IsActive)
	select CustomerId,NdcId,DateCreated,DateModified,CreatedByOrgRoleUserId,ModifiedByOrgRoleUserId,IsPrescribed,IsOtc,IsActive from TblCurrentMedication

	insert into TblEventCustomerCurrentMedication (EventCustomerId,NdcId,IsPrescribed,IsOtc)
	select ec.EventCustomerID,cm.NdcId,cm.IsPrescribed,cm.IsOtc from tblEventCustomers ec
		inner join TblCurrentMedication cm on ec.CustomerID = cm.CustomerId


	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCurrentMedication_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCurrentMedication]'))
		ALTER TABLE [dbo].[TblCurrentMedication] DROP CONSTRAINT [FK_TblCurrentMedication_TblCustomerProfile]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCurrentMedication_TblOrganizationRoleUser_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCurrentMedication]'))
	Begin
			ALTER TABLE [dbo].[TblCurrentMedication] DROP CONSTRAINT [FK_TblCurrentMedication_TblOrganizationRoleUser_CreatedBy]
	End
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCurrentMedication_TblOrganizationRoleUser_ModifiedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCurrentMedication]'))
	Begin
			ALTER TABLE [dbo].[TblCurrentMedication] DROP CONSTRAINT [FK_TblCurrentMedication_TblOrganizationRoleUser_ModifiedBy]
	End
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCurrentMedication_TblNdc]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCurrentMedication]'))
	BEGIN
		ALTER TABLE [dbo].[TblCurrentMedication] DROP CONSTRAINT [FK_TblCurrentMedication_TblNdc]
	END
	GO
	
	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCurrentMedication_IsPrescribed]') AND type = 'D')
	BEGIN
	   ALTER TABLE [dbo].[TblCurrentMedication] DROP CONSTRAINT [DF_TblCurrentMedication_IsPrescribed], COLUMN [IsPrescribed]
	END
	GO

	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCurrentMedication_IsOtc]') AND type = 'D')
	BEGIN
	   ALTER TABLE [dbo].[TblCurrentMedication] DROP CONSTRAINT [DF_TblCurrentMedication_IsOtc], COLUMN [IsOtc]
	END
	GO

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCurrentMedication]') AND type in (N'U'))
	BEGIN
		DROP TABLE [dbo].[TblCurrentMedication]
	END
	GO

	
CREATE TABLE [dbo].[TblCurrentMedication]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[NdcId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateEnd] [dateTime] null,	
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,	
	[IsActive] [bit] NOT NULL,
	IsPrescribed bit NOT NULL,
	IsOtc bit NOT NULL
	CONSTRAINT PK_TblCurrentMedicatio PRIMARY KEY ([Id])	
)
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblCurrentMedication_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCurrentMedication] CHECK CONSTRAINT [FK_TblCurrentMedication_TblCustomerProfile]
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblCurrentMedication_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCurrentMedication] CHECK CONSTRAINT [FK_TblCurrentMedication_TblOrganizationRoleUser_CreatedBy]
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblCurrentMedication_TblNdc] FOREIGN KEY([NdcId])
REFERENCES [dbo].[TblNdc] ([Id])
GO

ALTER TABLE [dbo].[TblCurrentMedication] CHECK CONSTRAINT [FK_TblCurrentMedication_TblNdc]
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [DF_TblCurrentMedication_IsPrescribed] Default 0 For IsPrescribed
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [DF_TblCurrentMedication_IsOtc] Default 0 For IsOtc
GO

Insert Into TblCurrentMedication  (CustomerId,NdcId,DateCreated,CreatedByOrgRoleUserId,IsPrescribed,IsOtc,IsActive)
	select CustomerId,NdcId,DateCreated,CreatedByOrgRoleUserId,IsPrescribed,IsOtc,IsActive from TblCurrentMedicationTemp

