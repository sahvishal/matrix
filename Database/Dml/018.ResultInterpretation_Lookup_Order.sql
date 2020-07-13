
USE [$(dbName)]
Go

update TblLookUp
set RelativeOrder=1
where Alias='Normal'


update TblLookUp
set RelativeOrder=2
where Alias='Abnormal'


update TblLookUp
set RelativeOrder=3
where Alias='Critical'


update TblLookUp
set RelativeOrder=4
where Alias='Urgent'