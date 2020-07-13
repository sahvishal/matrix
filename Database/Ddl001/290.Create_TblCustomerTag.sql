USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCustomerTag](
	[CustomerTagId] [bigint] IDENTITY(1,1) NOT NULL, 
	[CustomerId] [bigint] NOT NULL, 
	[Tag] [varchar](255) NOT NULL,	
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
	[IsActive] [bit] NOT NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblCustomerTag ADD CONSTRAINT
	PK_TblCustomerTag PRIMARY KEY CLUSTERED 
	(
	[CustomerTagId] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblCustomerTag]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerTag_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO   

ALTER TABLE [dbo].[TblCustomerTag]  ADD  CONSTRAINT [FK_TblCustomerTag_OrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO 

ALTER TABLE [dbo].[TblCustomerTag]  ADD  CONSTRAINT [FK_TblCustomerTag_OrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCustomerTag] ADD CONSTRAINT [DF_TblCustomerTag_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

 
 