USE [$(dbName)]
GO

CREATE Table TblEventCustomerQuestionAnswer
(
EventCustomerId bigint NOT NULL
,QuestionId bigint NOT NULL
,Answer varchar(200) NULL
,[Version] bigint NOT NULL
,IsActive bit NOT NULL
,CreatedBy bigint NULL
,CreatedDate Datetime NULL
,UpdatedBy bigint NULL
,UpdatedDate Datetime
 CONSTRAINT [PK_TblEventCustomerQuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[QuestionId] ASC,
	[Version] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblEventCustomerQuestionAnswer] ADD  CONSTRAINT [DF_TblEventCustomerQuestionAnswer_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblEventCustomerQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerQuestionAnswer_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblEventCustomerQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerQuestionAnswer_TblOrganizationRoleUser_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblEventCustomerQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerQuestionAnswer_TblEventCustomers_EventCustomerId] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] (EventCustomerID)
GO

ALTER TABLE [dbo].[TblEventCustomerQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerQuestionAnswer_TblPreQualificationQuestion_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblPreQualificationQuestion] (Id)
GO
