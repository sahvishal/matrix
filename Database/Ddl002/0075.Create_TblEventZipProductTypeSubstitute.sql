USE [$(dbName)]
GO

CREATE TABLE TblEventZipProductTypeSubstitute 
(
[Id] [bigint] IDENTITY(1,1) NOT NULL,
ZipID BIGINT NOT NULL,
ProductTypeId BIGINT  NOT NULL ,
CONSTRAINT PK_TblEventZipProductTypeSubstitute PRIMARY KEY ([Id]),

)
