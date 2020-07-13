USE [$(dbName)]
GO

ALTER TABLE TblPreQualificationQuestion
ALTER COLUMN IsActive bit NOT NULL 

IF EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'dbo.DF_TblPreQualificationQuestion_IsActive') AND parent_object_id = OBJECT_ID(N'dbo.TblPreQualificationQuestion'))
ALTER TABLE [dbo].[TblPreQualificationQuestion] DROP  CONSTRAINT [DF_TblPreQualificationQuestion_IsActive]

ALTER TABLE [dbo].[TblPreQualificationQuestion] ADD  CONSTRAINT [DF_TblPreQualificationQuestion_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE TblPreQualificationTestTemplate
ALTER COLUMN IsActive bit NOT NULL

ALTER TABLE TblPreQualificationTestTemplate
ALTER COLUMN IsPublished bit NOT NULL 

IF EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'dbo.DF_TblPreQualificationTestTemplate_IsActive') AND parent_object_id = OBJECT_ID(N'dbo.TblPreQualificationTestTemplate'))
ALTER TABLE [dbo].[TblPreQualificationTestTemplate] DROP  CONSTRAINT [DF_TblPreQualificationTestTemplate_IsActive]

ALTER TABLE [dbo].[TblPreQualificationTestTemplate] ADD  CONSTRAINT [DF_TblPreQualificationTestTemplate_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

IF EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'dbo.DF_TblPreQualificationTestTemplate_IsPublished') AND parent_object_id = OBJECT_ID(N'dbo.TblPreQualificationTestTemplate'))
ALTER TABLE [dbo].[TblPreQualificationTestTemplate] DROP  CONSTRAINT [DF_TblPreQualificationTestTemplate_IsPublished]

ALTER TABLE [dbo].[TblPreQualificationTestTemplate] ADD  CONSTRAINT [DF_TblPreQualificationTestTemplate_IsPublished] DEFAULT ((0)) FOR [IsPublished]
GO

ALTER TABLE TblEventCustomerQuestionAnswer
ALTER COLUMN IsActive bit NOT NULL

IF EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'dbo.DF_TblEventCustomerQuestionAnswer_IsActive') AND parent_object_id = OBJECT_ID(N'dbo.TblEventCustomerQuestionAnswer'))
ALTER TABLE [dbo].[TblEventCustomerQuestionAnswer] DROP  CONSTRAINT [DF_TblEventCustomerQuestionAnswer_IsActive]

ALTER TABLE [dbo].[TblEventCustomerQuestionAnswer] ADD  CONSTRAINT [DF_TblEventCustomerQuestionAnswer_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE TblDisqualifiedTest
ALTER COLUMN IsActive bit NOT NULL

IF EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'dbo.DF_TblDisqualifiedTest_IsActive') AND parent_object_id = OBJECT_ID(N'dbo.TblDisqualifiedTest'))
ALTER TABLE [dbo].[TblDisqualifiedTest] DROP  CONSTRAINT [DF_TblDisqualifiedTest_IsActive]

ALTER TABLE [dbo].[TblDisqualifiedTest] ADD  CONSTRAINT [DF_TblDisqualifiedTest_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE TblRequiredTest
ALTER COLUMN IsActive bit NOT NULL

IF EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'dbo.DF_TblRequiredTest_IsActive') AND parent_object_id = OBJECT_ID(N'dbo.TblRequiredTest'))
ALTER TABLE [dbo].[TblRequiredTest] DROP  CONSTRAINT [DF_TblRequiredTest_IsActive]

ALTER TABLE [dbo].[TblRequiredTest] ADD CONSTRAINT [DF_TblRequiredTest_IsActive] DEFAULT ((1)) FOR [IsActive]
GO



