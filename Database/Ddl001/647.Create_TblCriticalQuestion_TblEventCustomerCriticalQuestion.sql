USE [$(dbname)]
GO

CREATE TABLE TblCriticalQuestion
(
	[Id] BIGINT NOT NULL,
	[Question] NVARCHAR(MAX) NOT NULL,
	[ControlType] BIGINT NOT NULL,
	[ControlValues] VARCHAR(5000) NULL,
	[ControlValueDelimiter] VARCHAR(50) NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblCriticalQuestion_IsActive DEFAULT 0,
	CONSTRAINT PK_TblCriticalQuestion PRIMARY KEY([Id]),
	CONSTRAINT FK_TblCriticalQuestion_TblLookup FOREIGN KEY([ControlType]) REFERENCES [TblLookup]([LookupId])
)
GO


CREATE TABLE TblEventCustomerCriticalQuestion
(
	[EventCustomerId] BIGINT NOT NULL,
	[QuestionId] BIGINT NOT NULL,
	[Answer] VARCHAR(100) NOT NULL,
	CONSTRAINT PK_TblEventCustomerCriticalQuestion PRIMARY KEY([EventCustomerId], [QuestionId]),
	CONSTRAINT KK_TblEventCustomerCriticalQuestion_TblEventCustomers FOREIGN KEY([EventCustomerId]) REFERENCES [TblEventCustomers]([EventCustomerId]),
	CONSTRAINT KK_TblEventCustomerCriticalQuestion_TblCriticalQuestion FOREIGN KEY([QuestionId]) REFERENCES [TblCriticalQuestion]([Id])
)
GO