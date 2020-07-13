USE [$(dbname)]
GO

CREATE TABLE TblEventCustomerPrimaryCarePhysician
(
	EventCustomerId BIGINT NOT NULL,
	PrimaryCarePhysicianId BIGINT NOT NULL,
	
	CONSTRAINT PK_TblEventCustomerPrimaryCarePhysician PRIMARY KEY (EventCustomerId, PrimaryCarePhysicianId),
	CONSTRAINT FK_TblEventCustomerPrimaryCarePhysician_TblEventCustomers FOREIGN KEY (EventCustomerId) REFERENCES [TblEventCustomers](EventCustomerID),
	CONSTRAINT FK_TblEventCustomerPrimaryCarePhysician_TblCustomerPrimaryCarePhysician_PrimaryCarePhysicianId FOREIGN KEY (PrimaryCarePhysicianId) REFERENCES [TblCustomerPrimaryCarePhysician](PrimaryCarePhysicianId)
)
GO

ALTER TABLE [dbo].[TblCustomerPrimaryCarePhysician] add IsActive bit not null CONSTRAINT [DF_TblCustomerPrimaryCarePhysician_IsActive]  DEFAULT 1
GO