
USE [$(dbName)]
Go 

CREATE TABLE dbo.TblCallQueueCustomerLock
	(
	CallQueueCustomerId bigint NOT NULL 
						CONSTRAINT	PK_TblCallQueueCustomerLock PRIMARY KEY (CallQueueCustomerId)
						Constraint FK_TblCallQueueCustomerLock_TblCallQueueCustomer 
													Foreign Key (CallQueueCustomerId) REFERENCES TblCallQueueCustomer (CallQueueCustomerId),
	ProspectCustomerId bigint NULL,
	CustomerId bigint NULL
	) 
GO