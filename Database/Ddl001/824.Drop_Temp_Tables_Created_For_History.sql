USE [$(dbname)]
GO

IF OBJECT_ID('ZipId_Table', 'U') IS NOT NULL
DROP TABLE ZipId_Table
GO

--IF OBJECT_ID('DirectMailZips', 'U') IS NOT NULL
--DROP TABLE DirectMailZips
--GO

--IF OBJECT_ID('DirectMailDateId', 'U') IS NOT NULL
--DROP TABLE DirectMailDateId
--GO

IF OBJECT_ID('TblPreApprovedTestTemp', 'U') IS NOT NULL
DROP TABLE TblPreApprovedTestTemp
GO

IF OBJECT_ID('TblPreApprovedPackageTemp', 'U') IS NOT NULL
DROP TABLE TblPreApprovedPackageTemp
GO

IF OBJECT_ID('TblCustomerIcdCodeTemp', 'U') IS NOT NULL
DROP TABLE TblCustomerIcdCodeTemp
GO

IF OBJECT_ID('TblCurrentMedicationTemp', 'U') IS NOT NULL
DROP TABLE TblCurrentMedicationTemp
GO

IF OBJECT_ID('TblChaseOutboundTemp', 'U') IS NOT NULL
DROP TABLE TblChaseOutboundTemp
GO

IF OBJECT_ID('TblCustomerChaseCampaignTemp', 'U') IS NOT NULL
DROP TABLE TblCustomerChaseCampaignTemp
GO

IF OBJECT_ID('TblCustomerChaseChannelTemp', 'U') IS NOT NULL
DROP TABLE TblCustomerChaseChannelTemp
GO

IF OBJECT_ID('TblCustomerChaseProductTemp', 'U') IS NOT NULL
DROP TABLE TblCustomerChaseProductTemp
GO

IF OBJECT_ID('CustomerProfileTemp', 'U') IS NOT NULL
DROP TABLE CustomerProfileTemp
GO

IF OBJECT_ID('LoincLabDataTemp', 'U') IS NOT NULL
DROP TABLE LoincLabDataTemp
GO

--IF OBJECT_ID('TempTblEventCustomerPreApprovedTest', 'U') IS NOT NULL
--DROP TABLE TempTblEventCustomerPreApprovedTest
--GO