USE [$(dbName)]
Go

Update TblMedicareQuestion set DefaultValue='No' where QuestionId in (2,3,4,9)