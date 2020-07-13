
USE [$(dbName)]
Go

Alter Table TblShippingDetail Add IsRequested bit not null CONSTRAINT DF_TblShippingDetail_IsRequested DEFAULT 0