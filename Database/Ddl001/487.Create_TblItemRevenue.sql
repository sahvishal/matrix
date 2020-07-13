USE [$(dbName)]

GO

CREATE TABLE [dbo].[TblHealthPlanRevenueItem](
	Id bigint identity(1,1) not null,
	HealthPlanRevenueId	bigint	not null,
	PackageId bigint null,
	TestId bigint null,
	Price money not null
) 

GO

ALTER TABLE dbo.TblHealthPlanRevenueItem ADD CONSTRAINT PK_TblHealthPlanRevenueItem PRIMARY KEY CLUSTERED (Id)
GO


ALTER TABLE dbo.TblHealthPlanRevenueItem ADD CONSTRAINT FK_TblHealthPlanRevenueItem_TblHealthPlanRevenue FOREIGN KEY (HealthPlanRevenueId) REFERENCES dbo.TblHealthPlanRevenue(Id) 
GO

ALTER TABLE dbo.TblHealthPlanRevenueItem ADD CONSTRAINT FK_TblHealthPlanRevenueItem_TblPackage FOREIGN KEY (PackageId) REFERENCES dbo.TblPackage(PackageID) 	
GO

ALTER TABLE dbo.TblHealthPlanRevenueItem ADD CONSTRAINT FK_TblHealthPlanRevenueItem_TblTest FOREIGN KEY (TestId) REFERENCES dbo.TblTest(TestID)
go 