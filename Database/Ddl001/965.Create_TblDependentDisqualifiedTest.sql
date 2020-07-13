USE [$(dbname)]
GO

CREATE TABLE TblDependentDisqualifiedTest
(
	CustomerId BIGINT NOT NULL,
	EventId BIGINT NOT NULL,
	TestId BIGINT NOT NULL,
	[Version] INT NOT NULL,
	IsActive BIT NOT NULL CONSTRAINT DF_TblDependentDisqualifiedTest_IsActive DEFAULT (0),
	EventCustomerId BIGINT NULL,	
	CONSTRAINT PK_TblDependentDisqualifiedTest PRIMARY KEY (CustomerId, EventId, TestId, [Version]),
	CONSTRAINT FK_TblDependentDisqualifiedTest_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile]([CustomerId]),
	CONSTRAINT FK_TblDependentDisqualifiedTest_TblEvents FOREIGN KEY (EventId) REFERENCES [TblEvents]([EventId]),
	CONSTRAINT FK_TblDependentDisqualifiedTest_TblTest FOREIGN KEY (TestId) REFERENCES [TblTest]([TestId]),
	CONSTRAINT FK_TblDependentDisqualifiedTest_TblEventCustomers FOREIGN KEY (EventCustomerId) REFERENCES [TblEventCustomers]([EventCustomerId])
)

GO