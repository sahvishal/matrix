USE [$(dbName)]
GO

-- Add new customer left without screening reasons... Red Flag, CVT, NP, No Show

Declare @lookupTypeId bigint

SELECT @lookupTypeId = LookupTypeId from TblLookupType where alias = 'LeftWithoutScreeningReason'

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(365,@lookupTypeId ,'RedFlag','Red Flag','Red Flag',10,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(366,@lookupTypeId ,'CVT','CVT','CVT',11,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(367,@lookupTypeId ,'NP','NP','NP',12,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(368,@lookupTypeId ,'NoShow','No Show','No Show',13,GETDATE(),1,1)

GO