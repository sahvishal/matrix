
USE [$(dbName)]
GO


Alter Table TblCallQueueCriteria Add CallReason varchar(255) NULL
GO

Alter Table TblCallQueueCustomer Add CallDate datetime null
GO

Update TblCallQueueCustomer set CallDate  = DateCreated
GO

Alter Table TblCallQueueCustomer Alter Column CallDate datetime not null
GO

