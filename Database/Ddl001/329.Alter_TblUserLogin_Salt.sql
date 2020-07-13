USE [$(dbName)]
GO 

Alter table [TblUserLogin]
ADD [Salt] [nvarchar](64) NOT NULL CONSTRAINT DF_TblUserLogin_Salt DEFAULT 'notgenerated'

GO

 