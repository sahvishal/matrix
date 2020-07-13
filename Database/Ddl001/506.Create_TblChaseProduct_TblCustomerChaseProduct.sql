USE [$(dbname)]
GO

CREATE TABLE TblChaseProduct
(
	ChaseProductId BIGINT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(255) NOT NULL,
	ProductLevel BIGINT NOT NULL,
	CONSTRAINT PK_TblChaseProduct PRIMARY KEY (ChaseProductId)
)
GO

CREATE TABLE TblCustomerChaseProduct
(
	CustomerId BIGINT NOT NULL,
	ChaseProductId BIGINT NOT NULL,
	CONSTRAINT PK_TblCustomerChaseProduct PRIMARY KEY (CustomerId, ChaseProductId),
	CONSTRAINT FK_TblCustomerChaseProduct_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblCustomerChaseProduct_TblChaseProduct FOREIGN KEY (ChaseProductId) REFERENCES [TblChaseProduct](ChaseProductId)
)
GO