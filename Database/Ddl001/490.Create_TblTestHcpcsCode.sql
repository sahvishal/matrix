USE [$(dbName)]
GO
 
/****** Object:  Table [dbo].[TblTestHcpcsCode]    Script Date: 09-01-2017 12:57:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblTestHcpcsCode](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TestId] [bigint] NOT NULL,
	[HcpcsCodeId] [bigint] NOT NULL,
	[IsRetired] [bit] NOT NULL,
	[CreatedBy] bigint not null,
	[CreatedDate] datetime not null,
	[ModifiedBy]	bigint	null ,
	[ModifiedDate] datetime null,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_TblTestHcpcsCode_IsActive]  DEFAULT ((1)),
	
 CONSTRAINT [PK_TblTestHcpcsCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Foreign Key Constraint ******/
ALTER TABLE [dbo].[TblTestHcpcsCode]  WITH CHECK ADD  CONSTRAINT [FK_TblTestHcpcsCode_TblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestId])
GO
 
 
CREATE NONCLUSTERED INDEX [IX_TblTestHcpcsCode_Test] ON [dbo].[TblTestHcpcsCode]
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
/****** Object:  Foreign Key Constraint ******/
ALTER TABLE [dbo].[TblTestHcpcsCode]  WITH CHECK ADD  CONSTRAINT [FK_TblTestHcpcsCode_TblHcpcsCode] FOREIGN KEY([HcpcsCodeId])
REFERENCES [dbo].[TblHcpcsCode] ([Id])
GO
 
 
CREATE NONCLUSTERED INDEX [IX_TblTestHcpcsCode_TblHcpcsCode] ON [dbo].[TblTestHcpcsCode]
(
	[HcpcsCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
 

 ALTER TABLE TblTestHcpcsCode ADD CONSTRAINT FK_TblTestHcpcsCode_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) 
REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)

GO
ALTER TABLE TblTestHcpcsCode ADD CONSTRAINT FK_TblTestHcpcsCode_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy)
 REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)