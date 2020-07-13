USE [$(dbName)]
Go 


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE  TblAccessControlObject (
  Id bigint NOT NULL Identity(1,1) PRIMARY KEY ,
  Title varchar(512) NOT NULL,
  Description varchar(1024) NULL,
  ParentId bigint   NULL,
  DisplayOrder int  NULL 
    
)  

ALTER TABLE [dbo].[TblAccessControlObject]  WITH CHECK ADD  CONSTRAINT [FK_TblAccessControlObject_TblAccessControlObject1_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[TblAccessControlObject] ([Id])
GO