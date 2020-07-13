USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblRole]  
		ADD ParentId Bigint null
		
GO

ALTER TABLE [dbo].[TblRole]  WITH CHECK ADD  CONSTRAINT [FK_TblRole_TblRole1_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[TblRole] ([RoleId])
GO