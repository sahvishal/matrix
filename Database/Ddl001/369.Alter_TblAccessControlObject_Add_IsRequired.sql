USE [$(dbName)]
GO 

ALTER TABLE TblAccessControlObject
ADD IsRequired BIT NOT NULL CONSTRAINT DF_TblAccessControlObject_IsRequired DEFAULT(0)