use [$(dbName)]
go

CREATE TABLE [TblCustomerCallQueueCallAttempt]
(

	[CallAttemptID] BIGINT IDENTITY(1,1),
	[CallID] BIGINT NULL,
	[CustomerID] BIGINT NOT NULL,
	[CallQueueCustomerID] BIGINT NOT NULL ,
	[IsCallSkipped] BIT,
	[IsNotesReadAndUnderstood] BIT NULL,
	[NotInterestedReasonID] BIGINT NULL,
	[DateCreated] DATETIME,
	[CreatedBy] BIGINT,
	CONSTRAINT Pk_TblCustomerCallQueueCallAttempt PRIMARY KEY([CallAttemptID])

)ON [PRIMARY]


ALTER TABLE [TblCustomerCallQueueCallAttempt] 
WITH CHECK ADD  CONSTRAINT [FK_TblCustomerCallQueueCallAttempt_TblCalls_CallID]
FOREIGN KEY([CallID]) REFERENCES [TblCalls](CallID)

GO

ALTER TABLE [TblCustomerCallQueueCallAttempt] 
WITH CHECK ADD  CONSTRAINT [FK_TblCustomerCallQueueCallAttempt_TblCustomerProfile_CustomerID]
FOREIGN KEY([CustomerID]) REFERENCES [TblCustomerProfile](CustomerID)

GO

ALTER TABLE [TblCustomerCallQueueCallAttempt] 
WITH CHECK ADD  CONSTRAINT [FK_TblCustomerCallQueueCallAttempt_TblCallQueueCustomer_CallQueueCustomerId]
FOREIGN KEY([CallQueueCustomerID]) REFERENCES [TblCallQueueCustomer](CallQueueCustomerId)

GO

ALTER TABLE [TblCustomerCallQueueCallAttempt] 
WITH CHECK ADD  CONSTRAINT [FK_TblCustomerCallQueueCallAttempt_TblTag_TagId]
FOREIGN KEY([NotInterestedReasonID]) REFERENCES [TblTag](TagId)

GO

ALTER TABLE [TblCustomerCallQueueCallAttempt] 
WITH CHECK ADD  CONSTRAINT [FK_TblCustomerCallQueueCallAttempt_TblOrganizationRoleUser_OrganizationRoleUserID]
FOREIGN KEY([CreatedBy]) REFERENCES [TblOrganizationRoleUser](OrganizationRoleUserID)

GO