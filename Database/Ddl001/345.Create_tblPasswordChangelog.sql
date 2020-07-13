USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblPasswordChangelog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL , 
	[UserLoginId] [bigint] NOT NULL, 	
	[Password] [varchar](500) NOT NULL, 	
	[Salt] [nvarchar](128) NOT NULL, 
	[Sequence] [int] NOT NULL,	
	[DateCreated] [datetime] NOT NULL, 
	[CreatedByOrgRoleUserId] [bigint] NOT NULL
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblPasswordChangelog ADD CONSTRAINT
	PK_TblPasswordChangelog PRIMARY KEY CLUSTERED 
	(
	[Id] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblPasswordChangelog] ADD CONSTRAINT [FK_TblPasswordChangelog_TblUserLogin] FOREIGN KEY([UserLoginId])
REFERENCES [dbo].[TblUserLogin] ([UserLoginID])
GO   

ALTER TABLE [dbo].[TblPasswordChangelog] ADD CONSTRAINT [FK_TblPasswordChangelog_OrganizationRoleUser] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO 
 
 
  
   