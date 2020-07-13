
USE [$(dbName)]
Go


Alter Table TblTest Add IsSelectedByDefaultForEvent bit not null constraint DF_IsSelectedByDefaultForEvent_TblTest default(1)
