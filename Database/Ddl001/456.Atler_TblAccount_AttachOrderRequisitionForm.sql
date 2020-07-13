USE [$(dbName)]
GO

Alter Table TblAccount Add AttachOrderRequisitionForm bit NOT NULL Constraint DF_TblAccount_AttachOrderRequisitionForm default 0
GO
