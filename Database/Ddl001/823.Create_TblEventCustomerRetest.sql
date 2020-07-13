USE [$(dbname)]
GO

CREATE TABLE TblEventCustomerRetest
(
	EventCustomerId BIGINT NOT NULL,
	TestId BIGINT NOT NULL,
	DateCreated DATETIME NOT NULL CONSTRAINT DF_TblEventCustomerRetest_DateCreated DEFAULT GETDATE(),
	CreatedBy BIGINT NOT NULL,
	CONSTRAINT PK_TblEventCustomerRetest PRIMARY KEY ([EventCustomerId], [TestId]),
	CONSTRAINT FK_TblEventCustomerRetest_TblEventCustomers FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers]([EventCustomerId]),
	CONSTRAINT FK_TblEventCustomerRetest_TblTest FOREIGN KEY ([TestId]) REFERENCES [TblTest]([TestId]),
	CONSTRAINT FK_TblEventCustomerRetest_TblOrganizationRoleUser FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserID])
)

GO