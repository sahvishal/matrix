
USE [$(dbName)]
GO

Alter Table TblAccount Add CaptureInsuranceId bit not null Constraint DF_TblAccount_CaptureInsuranceId default 0
GO

Alter Table TblEvents Add CaptureInsuranceId bit not null Constraint DF_TblEvents_CaptureInsuranceId default 0
GO

Alter Table TblAccount Add InsuranceIdRequired bit not null Constraint DF_TblAccount_InsuranceIdRequired default 0
GO

Alter Table TblEvents Add InsuranceIdRequired bit not null Constraint DF_TblEvents_InsuranceIdRequired default 0
GO