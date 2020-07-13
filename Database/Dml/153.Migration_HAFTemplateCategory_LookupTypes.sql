USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Update TblHAFTemplate set Category=192 where HAFTemplateId > 0

Alter TABLE TblHAFTemplate ALTER COLUMN Category bigint NOT NULL

Go