USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblPayPeriod](
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[Name] Varchar(512) NOT NULL,
	[StartDate] DATETIME NOT NULL,	
	[EndDate] DATETIME NOT NULL,		
	[CreatedBy] BIGINT NOT NULL,	
	[CreatedOn] DATETIME NOT NULL,
	[ModifiedBy] BIGINT NULL,
	[ModifiedOn] DATETIME NULL,
	[IsActive]	BIT NOT NULL CONSTRAINT DF_TblPayPeriod_IsActiv DEFAULT 1,
	[IsPublished] BIT NOT NULL CONSTRAINT DF_TblPayPeriod_IsPublished DEFAULT 0,
	CONSTRAINT PK_TblPayPeriod PRIMARY KEY([Id])
	) ON [PRIMARY]

GO


ALTER TABLE [dbo].[TblPayPeriod]  WITH CHECK ADD  CONSTRAINT [FK_TblPayPeriod_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPayPeriod]  WITH CHECK ADD  CONSTRAINT [FK_TblPayPeriod_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO