USE [$(dbName)]
Go
 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE TblRoleAccessControlObject (
  RoleId bigint NOT NULL,
  AccessControlObjectId bigint NOT NULL,
  PermissionTypeId bigint NOT NULL,
  ScopeId bigint DEFAULT NULL,
  CONSTRAINT [PK_TblRoleAccessControlObject]  PRIMARY KEY CLUSTERED (RoleId,AccessControlObjectId)
)
GO
ALTER TABLE [dbo].[TblRoleAccessControlObject]  
					ADD  CONSTRAINT [FK_TblRoleAccessControlObject_Role] FOREIGN KEY([RoleId])
					REFERENCES [dbo].[TblRole] ([RoleId])
GO

ALTER TABLE [dbo].[TblRoleAccessControlObject]  
					ADD  CONSTRAINT [FK_TblRoleAccessControlObject_AccessControlObject] FOREIGN KEY([AccessControlObjectId])
					REFERENCES [dbo].[TblAccessControlObject] ([Id])
GO
ALTER TABLE [dbo].[TblRoleAccessControlObject]  
					ADD  CONSTRAINT [FK_TblRoleAccessControlObject_Tbllookup_PermissionTypeId] FOREIGN KEY([PermissionTypeId])
					REFERENCES [dbo].[TblLookup] ([LookupId])
GO
ALTER TABLE [dbo].[TblRoleAccessControlObject]  
					ADD  CONSTRAINT [FK_TblRoleAccessControlObject_Tbllookup_ScopeId] FOREIGN KEY([ScopeId])
					REFERENCES [dbo].[TblLookup] ([LookupId])
GO
 