USE [$(dbName)]

GO

CREATE TABLE [dbo].[TblAdditionalFields](
	[Id] [bigint] NOT NULL   CONSTRAINT PK_TblAdditionalFields PRIMARY KEY CLUSTERED (Id) ON [PRIMARY],
	[Name] nvarchar(255) Not Null,
	[Alias] nvarchar(255) not null,
	[DateCreated]  datetime not null ,
	[CreatedBy] Bigint not null,
	[ModifiedDate] datetime  null,
	[ModifiedBy] bigint  null
) 
GO

alter table [TblAdditionalFields] ADD CONSTRAINT FK_TblAdditionalFields_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)

alter table [TblAdditionalFields] ADD CONSTRAINT FK_TblAdditionalFields_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)