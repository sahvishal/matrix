USE [$(dbName)]
Go
 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE TblRoleScopeOption (
  RoleId bigint NOT NULL,
  ScopeId bigint NOT NULL,
  CONSTRAINT PK_TblRoleScopeOption PRIMARY KEY CLUSTERED(RoleId,ScopeId) 
)  

GO
ALTER TABLE [dbo].[TblRoleScopeOption]  
					ADD  CONSTRAINT [FK_TblRoleScopeOption_Role] FOREIGN KEY([RoleId])
					REFERENCES [dbo].[TblRole] ([RoleId])
GO
ALTER TABLE [dbo].[TblRoleScopeOption]  
					ADD  CONSTRAINT [FK_TblRoleScopeOption_Tbllookup_ScopeId] FOREIGN KEY([ScopeId])
					REFERENCES [dbo].[TblLookup] ([LookupId])
GO

