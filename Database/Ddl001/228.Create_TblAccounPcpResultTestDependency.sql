USE [$(dbName)]
Go

CREATE TABLE dbo.TblAccountPcpResultTestDependency
	(
	AccountId bigint NOT NULL,
	TestId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblAccountPcpResultTestDependency ADD CONSTRAINT
	PK_TblAccountPcpResultTestDependency PRIMARY KEY CLUSTERED 
	(
	AccountId,
	TestId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE dbo.TblAccountPcpResultTestDependency ADD CONSTRAINT
	FK_TblAccountPcpResultTestDependency_TblAccount FOREIGN KEY
	(
	AccountId
	) REFERENCES dbo.TblAccount
	(
	AccountID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TblAccountPcpResultTestDependency ADD CONSTRAINT
	FK_TblAccountPcpResultTestDependency_TblTest FOREIGN KEY
	(
	TestId
	) REFERENCES dbo.TblTest
	(
	TestID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO