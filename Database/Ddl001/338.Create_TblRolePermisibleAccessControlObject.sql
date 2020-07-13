USE [$(dbName)]
Go
 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE TblRolePermisibleAccessControlObject (
  RoleId bigint NOT NULL,
  AccessControlObjectId bigint NOT NULL,
  CONSTRAINT PK_TblRolePermisibleAccessControlObject PRIMARY KEY CLUSTERED(RoleId,AccessControlObjectId) 
)  

GO
ALTER TABLE [dbo].[TblRolePermisibleAccessControlObject]  
					ADD  CONSTRAINT [FK_TblRolePermisibleAccessControlObject_Role] FOREIGN KEY([RoleId])
					REFERENCES [dbo].[TblRole] ([RoleId])
GO
ALTER TABLE [dbo].[TblRolePermisibleAccessControlObject]  
					ADD  CONSTRAINT [FK_TblRolePermisibleAccessControlObject_TblAccessControlObject] FOREIGN KEY([AccessControlObjectId])
					REFERENCES [dbo].[TblAccessControlObject] ([Id])
GO

