USE [$(dbname)]
GO

ALTER TABLE TblEventCustomerQuestionAnswer
DROP CONSTRAINT PK_TblEventCustomerQuestionAnswer
GO

ALTER TABLE TblEventCustomerQuestionAnswer
ALTER COLUMN EventCustomerId BIGINT NULL
GO

ALTER TABLE TblEventCustomerQuestionAnswer
ADD CustomerId BIGINT NULL,
	EventId BIGINT NULL,
	CONSTRAINT FK_TblEventCustomerQuestionAnswer_TblCustomerProfile FOREIGN KEY ([CustomerId]) REFERENCES [TblCustomerProfile]([CustomerId]),
	CONSTRAINT FK_TblEventCustomerQuestionAnswer_TblEvents FOREIGN KEY ([EventId]) REFERENCES [TblEvents]([EventId])

GO