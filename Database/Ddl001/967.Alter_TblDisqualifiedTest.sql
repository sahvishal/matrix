USE [$(dbname)]
GO

ALTER TABLE TblDisqualifiedTest
DROP CONSTRAINT PK_TblDisqualifiedTest
GO

ALTER TABLE TblDisqualifiedTest
ALTER COLUMN EventCustomerId BIGINT NULL
GO

ALTER TABLE TblDisqualifiedTest
ADD CustomerId BIGINT NULL,
	EventId BIGINT NULL,
	CONSTRAINT FK_TblDisqualifiedTest_TblCustomerProfile FOREIGN KEY ([CustomerId]) REFERENCES [TblCustomerProfile]([CustomerId]),
	CONSTRAINT FK_TblDisqualifiedTest_TblEvents FOREIGN KEY ([EventId]) REFERENCES [TblEvents]([EventId])

GO