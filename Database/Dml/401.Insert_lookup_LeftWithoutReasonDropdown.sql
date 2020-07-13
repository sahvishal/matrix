USE[$(dbName)]

GO

Declare @lookupTypeId bigint

SELECT @lookupTypeId = LookupTypeId from TblLookupType where alias = 'LeftWithoutScreeningReason'

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(357,@lookupTypeId ,'WaitTime','Wait Time','Wait Time',4,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(358,@lookupTypeId ,'Mobility','Mobility','Mobility',5,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(359,@lookupTypeId ,'LanguageBarrier','Language Barrier','Language Barrier',6,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(360,@lookupTypeId ,'Critical/EMS','Critical/EMS','Critical/EMS',7,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(361,@lookupTypeId ,'RefusedToSignConsent','Refused to sign consent','Refused to sign consent',8,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(362,@lookupTypeId ,'Other','Other','Other',9,GETDATE(),1,1)

GO