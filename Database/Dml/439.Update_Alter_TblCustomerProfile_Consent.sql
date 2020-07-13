USE [$(dbName)]

GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--DECLARE @lookupTypeId bigint
--DECLARE @lookupIdforUnknownConsent bigint

--SELECT @lookupTypeId=LookupTypeID from TblLookupType where Alias='PatientConsent'
--SELECT @LookupIdforUnknownConsent=LookupId from TblLookup where Alias='Unknown' and LookupTypeId=@lookupTypeId
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

DECLARE @lookupIdforUnknownConsent bigint
SELECT @lookupIdforUnknownConsent = 405

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TblCustomerProfile
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
UPDATE TblCustomerProfile
SET 
PhoneHomeConsentId   = @lookupIdforUnknownConsent,
PhoneCellConsentId   = @lookupIdforUnknownConsent,
PhoneOfficeConsentId = @lookupIdforUnknownConsent
--WHERE PhoneHomeConsentId is NULL or PhoneCellConsentId is NULL or PhoneOfficeConsentId is NULL

GO
ALTER Table TblCustomerProfile
ALTER COLUMN PhoneHomeConsentId bigint not null

GO
ALTER Table TblCustomerProfile
ALTER COLUMN PhoneCellConsentId bigint not null

GO
ALTER Table TblCustomerProfile
ALTER COLUMN PhoneOfficeConsentId bigint not null

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TblCustomerProfileHistory
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @lookupIdforUnknownConsent bigint
SELECT @lookupIdforUnknownConsent = 405

UPDATE TblCustomerProfileHistory
SET 
PhoneHomeConsentId   = @lookupIdforUnknownConsent,
PhoneCellConsentId   = @lookupIdforUnknownConsent,
PhoneOfficeConsentId = @lookupIdforUnknownConsent
--WHERE PhoneHomeConsentId is NULL or PhoneCellConsentId is NULL or PhoneOfficeConsentId is NULL

GO
ALTER Table TblCustomerProfileHistory
ALTER COLUMN PhoneHomeConsentId bigint not null

GO
ALTER Table TblCustomerProfileHistory
ALTER COLUMN PhoneCellConsentId bigint not null

GO
ALTER Table TblCustomerProfileHistory
ALTER COLUMN PhoneOfficeConsentId bigint not null

GO