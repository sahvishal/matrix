USE [$(dbname)]
GO

INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
values (409,9,'InvalidNumber','Invalid Number','Invalid Number',9,GETDATE(),1,1)

