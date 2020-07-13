USE [$(dbName)]
GO

CREATE Table TblEventCustomerTestNotPerformedNotification
(
Id bigint not null identity(1,1),
EventCustomerId bigint not null,
NotificationTypeId int not null,
TestId bigint not null,
CreatedBy bigint not null,
DateCreated datetime not null
)

GO

Alter Table TblEventCustomerTestNotPerformedNotification
Add Constraint PK_TblEventCustomerTestNotPerformedNotification PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table TblEventCustomerTestNotPerformedNotification
Add Constraint FK_TblEventCustomerTestNotPerformedNotification_TblEventCustomers_EventCustomerId
Foreign Key ([EventCustomerId])
References [TblEventCustomers](EventCustomerId)

GO

Alter Table TblEventCustomerTestNotPerformedNotification
Add Constraint FK_TblEventCustomerTestNotPerformedNotification_TblNotificationType_NotificationTypeId
Foreign Key ([NotificationTypeID])
References [TblNotificationType](NotificationTypeID)

GO

Alter Table TblEventCustomerTestNotPerformedNotification
Add Constraint FK_TblEventCustomerTestNotPerformedNotification_TblTest_TestId
Foreign Key ([TestId])
References [TblTest](TestID)

GO

Alter Table TblEventCustomerTestNotPerformedNotification
Add Constraint FK_TblEventCustomerTestNotPerformedNotification_TblOrganizationRoleUser_CreatedBy
Foreign Key ([CreatedBy])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO