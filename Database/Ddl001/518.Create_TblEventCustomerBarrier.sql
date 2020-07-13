USE [$(dbName)]
Go
CREATE TABLE TblEventCustomerBarrier
(
	EventCustomerId bigint not null ,
	BarrierId bigint not null,
	Reason varchar(1020) not null,
	Resolution varchar(2040) null
	CONSTRAINT PK_TblEventCustomerBarrier PRIMARY KEY (EventCustomerId),
	CONSTRAINT FK_TblEventCustomerBarrier_TblEventCustomers_EventCustomerId FOREIGN KEY (EventCustomerId) REFERENCES TblEventCustomers(EventCustomerId),
	CONSTRAINT FK_TblEventCustomerBarrier_TblBarriers_BarrierId FOREIGN KEY (BarrierId) REFERENCES TblBarrier(Id)
)
GO
