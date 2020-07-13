USE [$(dbname)]
GO

CREATE TABLE TblCustomEventNotification
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[EventId] BIGINT NOT NULL,
	[AccountId] BIGINT NULL,
	[Body] VARCHAR(MAX) NULL,
	[CreatedDate] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[ServiceStatus] BIGINT NOT NULL,
	[ServiceDate] DATETIME NULL,
	CONSTRAINT PK_TblCustomEventNotification PRIMARY KEY ([Id]),
	CONSTRAINT FK_TblCustomEventNotification_TblEvents FOREIGN KEY ([EventId]) REFERENCES [TblEvents]([EventID]),
	CONSTRAINT FK_TblCustomEventNotification_TblAccount FOREIGN KEY ([AccountId]) REFERENCES [TblAccount]([AccountID]),
	CONSTRAINT FK_TblCustomEventNotification_TblOrganizationRoleUser FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserID]),
	CONSTRAINT FK_TblCustomEventNotification_TblLookup_ServiceStatus FOREIGN KEY ([ServiceStatus]) REFERENCES [TblLookup]([LookupID])
)
GO


CREATE TABLE TblEventCustomerCustomNotification
(
	[CustomEventNotificationId] BIGINT NOT NULL,
	[EventCustomerId] BIGINT NOT NULL,
	[Message] VARCHAR(MAX) NULL,
	CONSTRAINT PK_TblEventCustomerCustomNotification PRIMARY KEY ([CustomEventNotificationId], [EventCustomerId]),
	CONSTRAINT FK_TblEventCustomerCustomNotification_TblCustomEventNotification FOREIGN KEY ([CustomEventNotificationId]) REFERENCES [TblCustomEventNotification]([Id]),
	CONSTRAINT FK_TblEventCustomerCustomNotification_TblEventCustomers FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers]([EventCustomerID])
)
GO