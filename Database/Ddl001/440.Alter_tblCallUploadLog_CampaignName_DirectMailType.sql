USE [$(dbName)]
Go

Alter table TblCallUploadLog Add CampaignName nvarchar(512) Null,DirectMailType nvarchar(512) Null
Go
