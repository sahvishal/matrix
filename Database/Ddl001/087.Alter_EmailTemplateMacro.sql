USE [$(dbName)]
Go

Alter Table TblEmailTemplateMacro Add Sequence int null
Go

Update TblEmailTemplateMacro Set Sequence = 1 
Go

Alter Table TblEmailTemplateMacro Alter Column Sequence int not null
Go