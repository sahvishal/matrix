USE [$(dbname)]
GO

CREATE TABLE TblChaseChannelLevel
(
	ChaseChannelLevelId BIGINT IDENTITY(1,1) NOT NULL,
	ChannelName VARCHAR(255) NOT NULL,
	ChannelLevel BIGINT NOT NULL,
	CONSTRAINT PK_TblChaseChannelLevel PRIMARY KEY (ChaseChannelLevelId)
)
GO

CREATE TABLE TblCustomerChaseChannel
(
	CustomerId BIGINT NOT NULL,
	ChaseChannelLevelId BIGINT NOT NULL,
	CONSTRAINT PK_TblCustomerChaseChannel PRIMARY KEY (CustomerId, ChaseChannelLevelId),
	CONSTRAINT FK_TblCustomerChaseChannel_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblCustomerChaseChannel_TblChaseProduct FOREIGN KEY (ChaseChannelLevelId) REFERENCES [TblChaseChannelLevel](ChaseChannelLevelId)
)
GO