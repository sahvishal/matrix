USE [$(dbName)]

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TblCustomerProfile
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
ALTER Table TblCustomerProfile
ADD PhoneHomeConsentId bigint NULL

GO
ALTER Table TblCustomerProfile
ADD PhoneHomeConsentUpdateDate datetime NULL

GO
ALTER Table TblCustomerProfile
ADD PhoneCellConsentId bigint NULL

GO
ALTER Table TblCustomerProfile
ADD PhoneCellConsentUpdateDate datetime NULL

GO
ALTER Table TblCustomerProfile
ADD PhoneOfficeConsentId bigint NULL

GO
ALTER Table TblCustomerProfile
ADD PhoneOfficeConsentUpdateDate datetime NULL

GO
ALTER Table TblCustomerProfile
ADD Constraint FK_TblCustomerProfile_TblLookup_PhoneHomeConsentId
FOREIGN KEY (PhoneHomeConsentId)
References [TblLookup](LookupId)

GO
ALTER Table TblCustomerProfile
ADD Constraint FK_TblCustomerProfile_TblLookup_PhoneCellConsentId
FOREIGN KEY (PhoneCellConsentId)
References [TblLookup](LookupId)

GO
ALTER Table TblCustomerProfile
ADD Constraint FK_TblCustomerProfile_TblLookup_PhoneOfficeConsentId
FOREIGN KEY (PhoneOfficeConsentId)
References [TblLookup](LookupId)


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TblCustomerProfileHistory
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
ALTER Table TblCustomerProfileHistory
ADD PhoneHomeConsentId bigint NULL

GO
ALTER Table TblCustomerProfileHistory
ADD PhoneHomeConsentUpdateDate datetime NULL

GO
ALTER Table TblCustomerProfileHistory
ADD PhoneCellConsentId bigint NULL

GO
ALTER Table TblCustomerProfileHistory
ADD PhoneCellConsentUpdateDate datetime NULL

GO
ALTER Table TblCustomerProfileHistory
ADD PhoneOfficeConsentId bigint NULL

GO
ALTER Table TblCustomerProfileHistory
ADD PhoneOfficeConsentUpdateDate datetime NULL

GO