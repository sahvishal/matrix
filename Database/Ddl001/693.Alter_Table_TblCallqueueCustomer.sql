use[$(dbname)]
Go

Alter Table TblCallQueueCustomer

ADD FirstName varchar(50) null,
	MiddleName varchar(50) Null,
	LastName varchar(50) null,
	PhoneOffice varchar(50) Null,
	PhoneCell varchar(50) Null,
	PhoneHome varchar(50) Null,
	[ZipId] varchar(100)  Null,
	[ZipCode] varchar(100) Null,	
	Tag varchar(255) Null,

	IsEligble bit  Null,

	IsIncorrectPhoneNumber bit Not Null CONSTRAINT DF_TblCallQueueCustomer_IsIncorrectPhoneNumber DEFAULT 0,
	IsLanguageBarrier bit Not Null CONSTRAINT DF_TblCallQueueCustomer_IsLanguageBarrier DEFAULT 0,
	
	ActivityId bigint Null,
	DoNotContactTypeId bigint Null,
	DoNotContactReasonId bigint Null,
	DoNotContactUpdateDate datetime Null,

	CallCount bigInt null,
	AppointmentDate DateTime null,
	HasFutureAppointment bit Not Null CONSTRAINT DF_TblCallQueueCustomer_HasFutureAppointment DEFAULT 0,
	IsCallSkipped bit Not Null CONSTRAINT DF_TblCallQueueCustomer_IsCallSkipped DEFAULT 0,
	CallStatus bigint null ,
	ContactedDate DateTime  null,
	Disposition nvarchar(400) null,	
	CallBackRequestedDate DateTime null,
	AppointmentCancellationDate Datetime null
