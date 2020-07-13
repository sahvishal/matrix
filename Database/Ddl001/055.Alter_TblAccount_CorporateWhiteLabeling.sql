

USE [$(dbName)]
Go

Alter Table TblAccount Add CorporateWhiteLabeling bit not null CONSTRAINT DF_TblAccount_CorporateWhiteLabeling DEFAULT 0