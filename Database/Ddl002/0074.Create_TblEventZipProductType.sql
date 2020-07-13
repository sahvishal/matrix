
USE [$(dbName)]
GO

CREATE TABLE TblEventZipProductType  
(
[Id] [bigint] IDENTITY(1,1) NOT NULL,
ZipID BIGINT NOT NULL,
ProductTypeId BIGINT  NOT NULL
CONSTRAINT PK_TblEventZipProductType PRIMARY KEY ([Id]),
)
