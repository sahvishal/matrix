
USE [$(dbName)]
Go

Alter Table TblAccount Add AllowCobranding bit not null CONSTRAINT DF_TblAccount_AllowCobranding DEFAULT 0