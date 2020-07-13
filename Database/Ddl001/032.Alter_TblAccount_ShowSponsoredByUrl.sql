
USE [$(dbName)]
Go

update TblAccount
set CorpCode=UrlSuffix
where UrlSuffix is not null
go

sp_RENAME 'TblAccount.UrlSuffix' , 'ShowSponsoredByUrl', 'COLUMN'
go

update TblAccount
set ShowSponsoredByUrl=1
go

ALTER TABLE TblAccount Alter Column ShowSponsoredByUrl bit not null
go

ALTER TABLE TblAccount ADD CONSTRAINT [DF_TblAccount_ShowSponsoredByUrl] DEFAULT ((0)) FOR [ShowSponsoredByUrl]
go