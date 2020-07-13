USE [$(dbname)]
GO

CREATE TABLE TblEventCustomerResultTrale
(
	EventCustomerResultId BIGINT NOT NULL,
	ResponseId varchar(50) NOT NULL,
	DateCreated DateTime NOT NULL,
	CONSTRAINT PK_TblEventCustomerResultTrale PRIMARY KEY(EventCustomerResultId),
	CONSTRAINT FK_TblEventCustomerResultTrale_TblEventCustomerResult FOREIGN KEY ([EventCustomerResultId]) REFERENCES [TblEventCustomerResult]([EventCustomerResultId]),	
)
GO

CREATE TABLE TblCustomerTrale
(
	CustomerId BIGINT NOT NULL,
	UserId varchar(50) NOT NULL,
	DateCreated DateTime NOT NULL,
	CONSTRAINT PK_TblCustomerTrale PRIMARY KEY(CustomerId),
	CONSTRAINT FK_TblCustomerTrale_TblCustomerProfile FOREIGN KEY ([CustomerId]) REFERENCES [TblCustomerProfile]([CustomerID]),	
)
GO
