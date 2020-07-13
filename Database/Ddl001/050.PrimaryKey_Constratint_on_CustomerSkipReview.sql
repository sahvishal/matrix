USE [$(dbName)]
Go

Alter Table TblCustomerSkipReview Add Constraint PK_CustomerSkipReview Primary Key(EventCustomerId)