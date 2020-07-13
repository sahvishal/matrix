USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
  
CREATE TABLE TblAccessControlObjectUrl (
  Id bigint NOT NULL Identity(1,1) Primary Key,
  AccessControlObjectId bigint NOT NULL,
  Url varchar(1024) NOT NULL
) 

GO

ALTER TABLE [dbo].[TblAccessControlObjectUrl] 
WITH CHECK ADD
CONSTRAINT fk_AccessControlObjectUrl_AccessControlObject_Id FOREIGN KEY (AccessControlObjectId) REFERENCES [TblAccessControlObject] (Id)  
