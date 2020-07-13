USE [$(dbName)]
GO

CREATE TABLE dbo.TblAccountNotReviewableTest
	(
		AccountId bigint NOT NULL,
		TestId bigint NOT NULL
	)  ON [PRIMARY]
GO

ALTER TABLE dbo.TblAccountNotReviewableTest ADD CONSTRAINT PK_TblAccountNotReviewableTest PRIMARY KEY CLUSTERED (AccountId,TestId)  ON [PRIMARY]

GO

ALTER TABLE dbo.TblAccountNotReviewableTest ADD CONSTRAINT FK_TblAccountNotReviewableTest_TblAccount FOREIGN KEY (AccountId) REFERENCES dbo.TblAccount(AccountID) 
	
GO

ALTER TABLE dbo.TblAccountNotReviewableTest ADD CONSTRAINT FK_TblAccountNotReviewableTest_TblTest FOREIGN KEY (TestId) REFERENCES dbo.TblTest	(TestID)
	
GO

