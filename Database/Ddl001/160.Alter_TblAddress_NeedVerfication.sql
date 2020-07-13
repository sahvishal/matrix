
USE [$(dbName)]
GO
Alter Table TblAddress Add NeedVerification bit not null Constraint DF_TblAddress_NeedVerification default 0