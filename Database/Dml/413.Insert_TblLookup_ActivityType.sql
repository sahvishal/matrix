USE [$(dbName)]

GO

Declare @lookupTypeId bigint

SELECT @lookupTypeId = LookupTypeId from TblLookupType where alias = 'UploadActivityType'

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(364,@lookupTypeId ,'DoNotCallDoNotMail','Do not Call/Do not Email','Do not Call/Do not Email',4,GETDATE(),1,1)
