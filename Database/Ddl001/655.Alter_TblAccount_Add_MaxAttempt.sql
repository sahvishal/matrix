USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD IsMaxAttemptPerHealthPlan BIT NOT NULL CONSTRAINT DF_TblAccount_IsMaxAttemptPerHealthPlan DEFAULT 0,
	MaxAttempt INT NULL
GO