USE [$(dbName)]
GO

CREATE TABLE TblGuardianDetails
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] bigInt Not Null,
	[RelationshipId] bigInt Not Null,
	FirstName Varchar(50) not Null ,
	MiddleName Varchar(50) Null,
	LastName Varchar(50) Not Null,
	AddressId bigint null,
	PhoneCell Varchar(50) Null,
	PhoneOffice Varchar(50) Null,
	PhoneHome Varchar(50) Null,
	EMailId varchar(50)Null,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] bigInt NOT NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] bigInt NULL,
	IsActive bit not null,
	CONSTRAINT [PK_TblGuardianDetails] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblGuardianDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblGuardianDetails_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO


ALTER TABLE [dbo].[TblGuardianDetails] ADD  CONSTRAINT [DF_TblGuardianDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblGuardianDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblGuardianDetails_TblRelationship] FOREIGN KEY([RelationshipId])
REFERENCES [dbo].[TblRelationship] ([RelationshipId])
GO


ALTER TABLE [dbo].[TblGuardianDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblGuardianDetails_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblGuardianDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblGuardianDetails_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO
