USE [$(dbName)]
Go


CREATE TABLE [dbo].[TblTestNotPerformedReason](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](512) NOT NULL,
	[Alias] [varchar](512) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_TblTestNotPerformedReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) 

GO

ALTER TABLE [dbo].[TblTestNotPerformedReason]  WITH CHECK ADD  CONSTRAINT [FK_TblTestNotPerformedReason_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblTestNotPerformedReason] CHECK CONSTRAINT [FK_TblTestNotPerformedReason_TblOrganizationRoleUser_CreatedBy]
GO


