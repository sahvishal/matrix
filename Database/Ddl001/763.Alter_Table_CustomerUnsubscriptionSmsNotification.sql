Use [$(dbName)]
GO

CREATE TABLE TblSmsReceived
(
	Id bigint IDENTITY (1, 1) NOT NULL, 
	PhoneNumber Varchar(50) Not Null,
	DateCreated DateTime Not Null,
	[Message] varchar(200) 
)
GO

Alter Table TblSmsReceived
Add Constraint PK_TblSmsReceived PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



Create Table TblCustomerUnsubscribedSmsNotification
(
	Id bigInt IDENTITY (1, 1) NOT NULL, 
	CustomerId bigInt Not Null,	
	SmsReceivedId bigInt Not Null,
	StatusId bigInt not Null,
	DateCreated dateTime 		
)
Go

Alter Table TblCustomerUnsubscribedSmsNotification
Add Constraint PK_TblCustomerUnsubscribedSmsNotification PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table TblCustomerUnsubscribedSmsNotification
Add Constraint FK_TblCustomerUnsubscribedSmsNotification_TblCustomerProfile_CustomerId Foreign Key ([CustomerId])
References [TblCustomerProfile](CustomerId)

GO

Alter Table TblCustomerUnsubscribedSmsNotification
Add Constraint FK_TblCustomerUnsubscribedSmsNotification_TblSmsReceived_SmsReceivedId Foreign Key ([SmsReceivedId])
References [TblSmsReceived](Id)

GO


Alter Table TblCustomerUnsubscribedSmsNotification
Add Constraint FK_TblCustomerUnsubscribedSmsNotification_TblLookup_StatusId Foreign Key ([StatusId])
References [TblLookup](LookupId)

GO

ALTER TABLE TblCustomerProfile
	ADD IsSubscribed bit NULL
GO

ALTER TABLE TblCustomerProfileHistory
	ADD IsSubscribed bit NULL
GO