USE [$(dbName)]
GO

Alter Table TblOrderDetail 
		Add IsFromMedicare bit NOT NULL Constraint DF_TblOrderDetail_IsFromMedicare default 0
GO 

 