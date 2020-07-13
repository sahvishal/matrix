USE [$(dbName)]
GO

ALTER TABLE TblAccount
ADD AcesToHipIntake BIT NOT NULL CONSTRAINT DF_TblAccount_AcesToHipIntake DEFAULT 0,
 AcesToHipIntakeShortName VARCHAR(50) NULL

GO
