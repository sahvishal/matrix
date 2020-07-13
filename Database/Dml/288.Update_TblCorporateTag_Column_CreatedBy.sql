
USE [$(dbName)]
Go


update [TblCorporateTag] set CreatedBy=1 where CreatedBy is null 
Go

alter table [TblCorporateTag] 
alter column CreatedBy Bigint not null 
Go

