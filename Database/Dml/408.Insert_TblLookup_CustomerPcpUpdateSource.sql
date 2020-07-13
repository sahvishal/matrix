USE[$(dbName)]

GO

Declare @lookupTypeId bigint

INSERT INTO TblLookupType
(Alias,DisplayName,[Description],DateCreated,DateModified)
VALUES
('CustomerPcpUpdateSource','Customer Pcp Update Source','Used to store customer PCP Update source',
GETDATE(),NULL)

select @lookupTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(363,@lookupTypeId ,'CorporateUpload','Corporate Upload','Source of customer PCP info update is corporate upload',1,GETDATE(),1,1)

GO