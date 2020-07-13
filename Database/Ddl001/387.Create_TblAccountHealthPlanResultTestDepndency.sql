USE [$(dbName)]
GO


CREATE TABLE dbo.TblAccountHealthPlanResultTestDependency
	(
	AccountId bigint NOT NULL,
	TestId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblAccountHealthPlanResultTestDependency ADD CONSTRAINT
	PK_TblAccountHealthPlanResultTestDependency PRIMARY KEY CLUSTERED 
	(
	AccountId,
	TestId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE dbo.TblAccountHealthPlanResultTestDependency ADD CONSTRAINT
	FK_TblAccountHealthPlanResultTestDependency_TblAccount FOREIGN KEY
	(
	AccountId
	) REFERENCES dbo.TblAccount
	(
	AccountID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TblAccountHealthPlanResultTestDependency ADD CONSTRAINT
	FK_TblAccountHealthPlanResultTestDependency_TblTest FOREIGN KEY
	(
	TestId
	) REFERENCES dbo.TblTest
	(
	TestID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

