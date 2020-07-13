USE [$(dbName)]
GO

/****** Object:  Table [dbo].[TblAccountTestHcpcsCode]    Script Date: 09-01-2017 19:11:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
  
CREATE TABLE [dbo].[TblAccountTestHcpcsCode](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[TestHcpcsCodeId] [bigint] NOT NULL,
	[CreatedBy] bigint not null,
	[CreatedDate] datetime not null,
	[ModifiedBy]	bigint	null ,
	[ModifiedDate] datetime null,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblAccountTestHcpcsCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblAccountTestHcpcsCode] ADD  CONSTRAINT [DF_TblAccountTestHcpcsCode_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblAccountTestHcpcsCode]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountTestHcpcsCode_Organization] FOREIGN KEY([AccountId])
REFERENCES [dbo].[TblOrganization] ([OrganizationId])
GO

ALTER TABLE [dbo].[TblAccountTestHcpcsCode] CHECK CONSTRAINT [FK_TblAccountTestHcpcsCode_Organization]
GO

ALTER TABLE [dbo].[TblAccountTestHcpcsCode]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountTestHcpcsCode_TestHcpcsCode] FOREIGN KEY([TestHcpcsCodeId])
REFERENCES [dbo].[TblTestHcpcsCode] ([Id])
GO

ALTER TABLE [dbo].[TblAccountTestHcpcsCode] CHECK CONSTRAINT [FK_TblAccountTestHcpcsCode_TestHcpcsCode]
GO


 
ALTER TABLE TblAccountTestHcpcsCode ADD CONSTRAINT FK_TblAccountTestHcpcsCode_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) 
REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)

GO
ALTER TABLE TblAccountTestHcpcsCode ADD CONSTRAINT FK_TblAccountTestHcpcsCode_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy)
 REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)

 