USE [$(dbName)]
GO

Alter table TblRaps 
Drop Column HraId 

Alter Table TblRaps
Drop Column Version 


Alter Table TblRaps
Add IsSynced bit NOT NULL CONSTRAINT [DF_TblRaps_IsSynced]  DEFAULT ((0))

alter table TblrapsUpload 
Add TotalCount bigint null

go 
Update TblRapsUpload set TotalCount  =SuccessfullUploadCount + FailedUploadCount

go 
alter table TblrapsUpload 
Alter Column TotalCount bigint not null


Alter table TblRapsUploadLog 
Drop Column HraId 