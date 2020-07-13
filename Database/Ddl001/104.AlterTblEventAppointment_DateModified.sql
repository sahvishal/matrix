USE [$(dbName)]
Go
Alter Table TblEventAppointment Alter Column DateModified DateTime Null

--Alter Table TblEventAppointment Add DateModified DateTime Null