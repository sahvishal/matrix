
USE [$(dbName)]
GO

CREATE TABLE TblTestPerformedExternally 
(
 Id bigint IDENTITY(1,1) NOT NULL 
,CustomerEventScreeningTestId BIGINT NOT NULL 
,EntryCompleted BIT NOT NULL 
,ResultEntryTypeId BIGINT NOT NULL
,CreatedBy BIGINT NOT NULL
,CreatedDate DATETIME NOT NULL 
,ModifiedBy BIGINT NULL 
,ModifiedDate DATETIME NULL 
 CONSTRAINT [PK_TblTestPerformedExternally] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[TblTestPerformedExternally]  WITH CHECK ADD  CONSTRAINT [FK_TblTestPerformedExternally_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblTestPerformedExternally]  WITH CHECK ADD  CONSTRAINT [FK_TblTestPerformedExternally_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblTestPerformedExternally]  WITH CHECK ADD  CONSTRAINT [FK_TblTestPerformedExternally_TblOrganizationRoleUser_ResultEntryTypeId] FOREIGN KEY([ResultEntryTypeId])
REFERENCES [dbo].[TblLookUp] ([LookUpId])
GO

ALTER TABLE [dbo].[TblTestPerformedExternally]  WITH CHECK ADD  CONSTRAINT [FK_TblTestPerformedExternally_TblCustomerEventScreeningTests_CustomerEventScreeningTestId] 
FOREIGN KEY([CustomerEventScreeningTestId])
REFERENCES [dbo].[TblCustomerEventScreeningTests] ([CustomerEventScreeningTestId])
GO
