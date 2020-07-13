USE [$(dbName)]
GO
 
/****** Object:  Table [dbo].[TblHcpcsCode]    Script Date: 09-01-2017 18:44:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblHcpcsCode](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Description] [varchar](1024) NULL,
	[Cost] [decimal](9, 2) NULL,
	[CopayCost] [decimal](9, 2) NULL,
	[IsRetired] [bit] NOT NULL,
	[CreatedBy] bigint not null,
	[CreatedDate] datetime not null,
	[ModifiedBy]	bigint	null ,
	[ModifiedDate] datetime null,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_TblHcpcsCode_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_TblHcpcsCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

 ALTER TABLE TblHcpcsCode ADD CONSTRAINT FK_TblHcpcsCode_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) 
REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)

GO
ALTER TABLE TblHcpcsCode ADD CONSTRAINT FK_TblHcpcsCode_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy)
 REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)


