USE [$(dbName)]
Go 


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

Alter TABLE  TblAccessControlObject  
ADD  Alias varchar(512)   NULL 

GO

Update TblAccessControlObject set Alias = Title

GO

Alter TABLE  TblAccessControlObject  
Alter Column  Alias varchar(512) NOT  NULL 