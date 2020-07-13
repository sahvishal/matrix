USE [$(dbName)]
GO

ALTER TABLE TblEventCustomers
ADD IsParticipationConsentSigned BIT NOT NULL CONSTRAINT DF_TblEventCustomers_IsParticipationConsentSigned DEFAULT 0,
	IsPhysicianRecordRequestSigned BIT NOT NULL CONSTRAINT DF_TblEventCustomers_IsPhysicianRecordRequestSigned DEFAULT 0,
	IsFluVaccineConsentSigned BIT NOT NULL CONSTRAINT DF_TblEventCustomers_IsFluVaccineConsentSigned DEFAULT 0

GO