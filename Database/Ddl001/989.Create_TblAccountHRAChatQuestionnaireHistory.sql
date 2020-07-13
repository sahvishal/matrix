USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE TblAccountHraChatQuestionnaireHistory
(
 Id bigint identity(1,1) NOT NULL,
 AccountId bigint NOT NULL,
 QuestionnaireType bigint NOT NULL,
 StartDate DateTime NULL,
 EndDate Datetime NULL,
 CreatedOn Datetime NULL,
 CreatedBy bigint NULL, 
 ModifiedOn Datetime NULL, 
 ModifiedBy bigint NULL 
 
CONSTRAINT [PK_TblAccountHraChatQuestionnaireHistory] PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaireHistory]  WITH CHECK ADD CONSTRAINT [FK_TblAccountHraChatQuestionnaireHistory_TblAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[TblAccount] ([AccountId])
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaireHistory]  WITH CHECK ADD CONSTRAINT [FK_TblAccountHraChatQuestionnaireHistory_TblLookup] FOREIGN KEY([QuestionnaireType])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO  

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaireHistory]  WITH CHECK ADD CONSTRAINT [FK_TblAccountHraChatQuestionnaireHistory_TblOrganizationRoleUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO  

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaireHistory]  WITH CHECK ADD CONSTRAINT [FK_TblAccountHraChatQuestionnaireHistory_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO  


