
USE [$(dbName)]
Go

Alter Table TblRefundRequest Alter Column ReasonComment varchar(max) not null
Go

Alter Table TblRefundRequest Alter Column ProcessorNotes varchar(max) null
Go