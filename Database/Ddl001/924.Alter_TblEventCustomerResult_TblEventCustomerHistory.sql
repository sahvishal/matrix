USE [$(dbName)]
GO


ALTER TABLE TblEventCustomerResult ADD  SignedOffBy bigint NULL
ALTER TABLE TblEventCustomerResult ADD  SignedOffOn DateTime NULL
GO

ALTER TABLE [dbo].[TblEventCustomerResult]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerResult_TblOrganizationRoleUser_SignedOffBy] FOREIGN KEY(SignedOffBy)
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE TblEventCustomerResult ADD  VerifiedBy bigint NULL
ALTER TABLE TblEventCustomerResult ADD  VerifiedOn DateTime NULL
GO

ALTER TABLE [dbo].[TblEventCustomerResult]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerResult_TblOrganizationRoleUser_VerifiedBy] FOREIGN KEY([VerifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE TblEventCustomerResult ADD  CodedBy bigint NULL
ALTER TABLE TblEventCustomerResult ADD  CodedOn DateTime NULL
GO

ALTER TABLE [dbo].[TblEventCustomerResult]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerResult_TblOrganizationRoleUser_CodedBy] FOREIGN KEY([CodedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE TblEventCustomerResult ADD AcesApprovedOn DateTime NULL
GO


CREATE TABLE [dbo].[TblEventCustomerResultHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventCustomerResultId] [bigint] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[EventID] [bigint] NOT NULL,
	[IsClinicalFormGenerated] [bit] NOT NULL,
	[IsResultPDFGenerated] [bit] NOT NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[ResultState] [int] NOT NULL,
	[IsPartial] [bit] NOT NULL,
	[ResultSummary] [bigint] NULL,
	[PathwayRecommendation] [bigint] NULL,
	[RegenerationDate] [datetime] NULL,
	[RegeneratedBy] [bigint] NULL,
	[IsFasting] [bit] NULL,
	[IsRevertedToEvaluation] [bit] NOT NULL,
	[IsPennedBack] [bit] NOT NULL,
	SignedOffBy [bigint] NULL,
	SignedOffOn [datetime] NULL,
	VerifiedBy [bigint] NULL,
	VerifiedOn [datetime] NULL,
	CodedBy [bigint] NULL,
	CodedOn [datetime] NULL,
	AcesApprovedOn [datetime] NULL


 CONSTRAINT [PK_TblEventCustomerResultHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
