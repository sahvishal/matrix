
USE [$(dbName)]
Go

Alter Table TblShippingDetail Drop Constraint DF_TblShippingDetail_IsRequested
Go

Alter Table TblShippingDetail Drop Column IsRequested
GO

Alter Table TblShippingDetail Add IsExclusivelyRequested bit not null CONSTRAINT DF_TblShippingDetail_IsExclusivelyRequested DEFAULT 0