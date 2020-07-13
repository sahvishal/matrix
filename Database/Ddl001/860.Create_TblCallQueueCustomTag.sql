USE [$(dbname)]
GO

CREATE TABLE TblCallQueueCustomTag
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[HealthPlanId] BIGINT NOT NULL,
	[CustomTag] VARCHAR(255) NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT DF_TblCallQueueCustomTag_DateCreated DEFAULT GETDATE(),
	[CreatedBy] BIGINT NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblCallQueueCustomTag_IsActive DEFAULT 1,
	CONSTRAINT PK_TblCallQueueCustomTag PRIMARY KEY([Id]),
	CONSTRAINT FK_TblCallQueueCustomTag_TblAccount FOREIGN KEY([HealthPlanId]) REFERENCES [TblAccount]([AccountId]),
	CONSTRAINT FK_TblCallQueueCustomTag_TblOrganizationRoleUser FOREIGN KEY([CreatedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserID])
)

GO