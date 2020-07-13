USE [$(dbname)]
GO

CREATE TABLE TblCustomerOrderHistory
(
	UploadId BIGINT NOT NULL,
	EventCustomerId BIGINT NOT NULL,
	EventId BIGINT NOT NULL,
	CustomerId BIGINT NOT NULL,
	EventPackageId BIGINT NULL,
	EventTestId BIGINT NULL,
	OrderItemStatusId BIGINT NOT NULL
)

ALTER TABLE TblCustomerOrderHistory
ADD CONSTRAINT FK_TblCustomerOrderHistory_TblCorporateUpload_UploadId
FOREIGN KEY (UploadId)
REFERENCES [TblCorporateUpload](Id)
GO

ALTER TABLE TblCustomerOrderHistory
ADD CONSTRAINT FK_TblCustomerOrderHistory_TblEventCustomers_EventCustomerId
FOREIGN KEY (EventCustomerId)
REFERENCES [TblEventCustomers](EventCustomerId)
GO

ALTER TABLE TblCustomerOrderHistory
ADD CONSTRAINT FK_TblCustomerOrderHistory_TblEvents_EventId
FOREIGN KEY (EventId)
REFERENCES [TblEvents](EventId)
GO

ALTER TABLE TblCustomerOrderHistory
ADD CONSTRAINT FK_TblCustomerOrderHistory_TblCustomerProfile_CustomerId
FOREIGN KEY (CustomerId)
REFERENCES [TblCustomerProfile](CustomerId)
GO

ALTER TABLE TblCustomerOrderHistory
ADD CONSTRAINT FK_TblCustomerOrderHistory_TblEventPackage_EventPackageId
FOREIGN KEY (EventPackageId)
REFERENCES [TblEventPackageDetails](EventPackageId)
GO

ALTER TABLE TblCustomerOrderHistory
ADD CONSTRAINT FK_TblCustomerOrderHistory_TblEventTest_EventTestId
FOREIGN KEY (EventTestId)
REFERENCES [TblEventTest](EventTestId)
GO

ALTER TABLE TblCustomerOrderHistory
ADD CONSTRAINT FK_TblCustomerOrderHistory_TblLookup_OrderItemStatusId
FOREIGN KEY (OrderItemStatusId)
REFERENCES [TblLookup](LookupId)
GO
