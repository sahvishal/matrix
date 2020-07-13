USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblEventCustomerResultBloodLab](
	[EventCustomerResultId] [bigint] NOT NULL, 
	[IsFromNewLab] [bit] NOT NULL, 	
	[DateCreated] [datetime] NOT NULL, 
	[CreatedByOrgRoleUserid] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblEventCustomerResultBloodLab ADD CONSTRAINT
	PK_TblEventCustomerResultBloodLab PRIMARY KEY CLUSTERED 
	(
	[EventCustomerResultId] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblEventCustomerResultBloodLab]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerResultBloodLab_TblEventCustomerResult] FOREIGN KEY([EventCustomerResultId])
REFERENCES [dbo].[TblEventCustomerResult] ([EventCustomerResultId])
GO   

ALTER TABLE [dbo].[TblEventCustomerResultBloodLab]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerResultBloodLab_TblOrganizationRoleUser] FOREIGN KEY([CreatedByOrgRoleUserid])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO 
 
ALTER TABLE [dbo].[TblEventCustomerResultBloodLab] ADD CONSTRAINT [DF_TblEventCustomerResultBloodLab_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

 
  
  