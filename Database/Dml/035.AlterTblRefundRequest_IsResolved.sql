
USE [$(dbName)]
Go

Alter Table TblRefundRequest Drop Constraint DF__TblRefund__IsRes__768C7B8D
Alter Table TblRefundRequest Drop Column IsResolved 
Go