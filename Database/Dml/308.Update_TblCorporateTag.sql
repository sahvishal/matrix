USE [$(dbName)]
Go

update TblCorporateTag set StartDate=CAST(DateCreated as date ), EndDate =  DATEADD(YEAR,1, cast(DateCreated as date )) where StartDate is null and  EndDate is null

alter table TblCorporateTag alter column StartDate Datetime not null  
alter table TblCorporateTag alter column EndDate Datetime not null 


