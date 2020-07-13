USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblActivityType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL, 
	[Name] [varchar](255) NOT NULL, 
	[Alias] [varchar](255) NOT NULL, 	
	[CreatedDate] [datetime] NOT NULL, 
	[CreatedBy] [BIGINT] NOT NULL,
	[IsActive] [bit] NOT NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblActivityType ADD CONSTRAINT
	PK_TblActivityType PRIMARY KEY CLUSTERED 
	(
	[Id] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblActivityType]  WITH CHECK ADD  CONSTRAINT [FK_TblActivityType_TblOrganizationRoleUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO   
 
ALTER TABLE [dbo].[TblActivityType] ADD CONSTRAINT [DF_TblActivityType_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

 
  
  