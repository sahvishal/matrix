USE [$(dbName)]
GO

Alter Table TblAccount Add CapturePCPConsent bit NOT NULL Constraint DF_TblAccount_CapturePCPConsent default 0
GO

Alter Table TblAccount Add CaptureABNStatus bit NOT NULL Constraint DF_TblAccount_CaptureABNStatus default 0
GO

Alter Table TblAccount Add AllowPrePayment bit NOT NULL Constraint DF_TblAccount_AllowPrePayment default 1
GO

Alter Table TblAccount Add HICNumberRequired bit NOT NULL Constraint DF_TblAccount_HICNumberRequired default 0
GO

