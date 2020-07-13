USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblLab](
	[Id] [bigint] IDENTITY(1,1) NOT NULL, 
	[Name] [varchar](255) NOT NULL, 	
	[Alias] [varchar](255) NOT NULL, 	
	[DateCreated] [datetime] NOT NULL, 
	[CreatedByOrgRoleUserId] [BIGINT] NOT NULL,
	[IsActive] [bit] NOT NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblLab ADD CONSTRAINT
	PK_TblLab PRIMARY KEY CLUSTERED 
	(
	[Id] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblLab]  WITH CHECK ADD  CONSTRAINT [FK_TblLab_TblOrganizationRoleUser] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO   
 
ALTER TABLE [dbo].[TblLab] ADD CONSTRAINT [DF_TblLab_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

 
  
  