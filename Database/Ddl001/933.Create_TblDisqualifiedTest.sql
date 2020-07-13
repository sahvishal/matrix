USE [$(dbName)]
GO

CREATE Table TblDisqualifiedTest
(
 TestId bigint NOT NULL
,EventCustomerId bigint NOT NULL
,QuestionId bigint NOT NULL
,Answer varchar(200) NULL
,[Version] bigint NOT NULL
,IsActive bit NOT NULL
,CreatedBy bigint NULL
,CreatedDate Datetime NULL
,UpdatedBy bigint NULL
,UpdatedDate Datetime
 CONSTRAINT [PK_TblDisqualifiedTest] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[QuestionId] ASC,
	[Version] ASC,
	TestId ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblDisqualifiedTest] ADD  CONSTRAINT [DF_TblDisqualifiedTest_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblDisqualifiedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblDisqualifiedTest_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblDisqualifiedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblDisqualifiedTest_TblOrganizationRoleUser_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblDisqualifiedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblDisqualifiedTest_TblEventCustomers_EventCustomerId] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] (EventCustomerID)
GO

ALTER TABLE [dbo].[TblDisqualifiedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblDisqualifiedTest_TblPreQualificationQuestion_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblPreQualificationQuestion] ([Id])
GO

ALTER TABLE [dbo].[TblDisqualifiedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblDisqualifiedTest_TblTest_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestId])
GO


