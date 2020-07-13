USE [$(dbName)]
Go


CREATE TABLE [dbo].[TblTestNotPerformed](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerEventScreeningTestId] [bigint] NOT NULL,
	[TestNotPerformedReasonId] [bigint] NOT NULL,
	[Notes] [nvarchar](2048) NULL,
	[IsManual] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	 CONSTRAINT [PK_TblTestNotPerformed] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	) ON [PRIMARY]
) 

GO

ALTER TABLE [dbo].[TblTestNotPerformed]  WITH CHECK ADD  CONSTRAINT [FK_TblTestNotPerformed_TblCustomerEventScreeningTests_CustomerEventScreeningTestId] FOREIGN KEY([CustomerEventScreeningTestId])
REFERENCES [dbo].[TblCustomerEventScreeningTests] ([CustomerEventScreeningTestID])
GO

ALTER TABLE [dbo].[TblTestNotPerformed] CHECK CONSTRAINT [FK_TblTestNotPerformed_TblCustomerEventScreeningTests_CustomerEventScreeningTestId]
GO

ALTER TABLE [dbo].[TblTestNotPerformed]  WITH CHECK ADD  CONSTRAINT [FK_TblTestNotPerformed_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblTestNotPerformed] CHECK CONSTRAINT [FK_TblTestNotPerformed_TblOrganizationRoleUser_CreatedBy]
GO

ALTER TABLE [dbo].[TblTestNotPerformed]  WITH CHECK ADD  CONSTRAINT [FK_TblTestNotPerformed_TblOrganizationRoleUser_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblTestNotPerformed] CHECK CONSTRAINT [FK_TblTestNotPerformed_TblOrganizationRoleUser_UpdatedBy]
GO

ALTER TABLE [dbo].[TblTestNotPerformed]  WITH CHECK ADD  CONSTRAINT [FK_TblTestNotPerformed_TblTestNotPerformedReason_TestNotPerformedReasonId] FOREIGN KEY([TestNotPerformedReasonId])
REFERENCES [dbo].[TblTestNotPerformedReason] ([Id])
GO

ALTER TABLE [dbo].[TblTestNotPerformed] CHECK CONSTRAINT [FK_TblTestNotPerformed_TblTestNotPerformedReason_TestNotPerformedReasonId]
GO


