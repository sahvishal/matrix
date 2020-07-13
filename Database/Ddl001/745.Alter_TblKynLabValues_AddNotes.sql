USE [$(dbname)]
GO

ALTER TABLE TblKynLabValues
ADD Notes varchar(Max)
GO