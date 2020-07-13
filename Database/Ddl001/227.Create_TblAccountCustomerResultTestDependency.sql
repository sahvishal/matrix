
USE [$(dbName)]
Go

CREATE TABLE dbo.TblAccountCustomerResultTestDependency
	(
	AccountId bigint NOT NULL,
	TestId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblAccountCustomerResultTestDependency ADD CONSTRAINT
	PK_TblAccountCustomerResultTestDependency PRIMARY KEY CLUSTERED 
	(
	AccountId,
	TestId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TblAccountCustomerResultTestDependency ADD CONSTRAINT
	FK_TblAccountCustomerResultTestDependency_TblAccount FOREIGN KEY
	(
	AccountId
	) REFERENCES dbo.TblAccount
	(
	AccountID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TblAccountCustomerResultTestDependency ADD CONSTRAINT
	FK_TblAccountCustomerResultTestDependency_TblTest FOREIGN KEY
	(
	TestId
	) REFERENCES dbo.TblTest
	(
	TestID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO




