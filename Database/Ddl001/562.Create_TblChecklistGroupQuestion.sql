USE [$(dbname)]
GO

CREATE TABLE [TblChecklistGroupQuestion]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[GroupId] BIGINT NOT NULL,
	[QuestionId] BIGINT NOT NULL,
	[ParentId] BIGINT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblChecklistGroupQuestion_IsActive DEFAULT(1),
	CONSTRAINT PK_TblChecklistGroupQuestion PRIMARY KEY([Id]),
	CONSTRAINT FK_TblChecklistGroupQuestion_TblChecklistGroup FOREIGN KEY ([GroupId]) REFERENCES [TblChecklistGroup]([Id]),
	CONSTRAINT FK_TblChecklistGroupQuestion_TblChecklistQuestion_QuestionId FOREIGN KEY ([QuestionId]) REFERENCES [TblChecklistQuestion]([Id]),
	CONSTRAINT FK_TblChecklistGroupQuestion_TblChecklistQuestion_ParentId FOREIGN KEY ([ParentId]) REFERENCES [TblChecklistQuestion]([Id])
)
GO

ALTER TABLE [TblChecklistTemplateQuestion] 
ADD [GroupQuestionId] BIGINT NULL,
	CONSTRAINT FK_TblChecklistTemplateQuestion_TblChecklistGroupQuestion FOREIGN KEY([GroupQuestionId]) REFERENCES [TblChecklistGroupQuestion]([Id])
GO


CREATE TABLE [TblEventChecklistTemplate]
(
	[EventId] BIGINT NOT NULL,
	[ChecklistTemplateId] BIGINT NOT NULL,
	CONSTRAINT PK_TblEventChecklistTemplate PRIMARY KEY([EventId], [ChecklistTemplateId]),
	CONSTRAINT FK_TblEventChecklistTemplate_TblEvents FOREIGN KEY([EventId]) REFERENCES [TblEvents](EventID),
	CONSTRAINT FK_TblEventChecklistTemplate_TblChecklistTemplate FOREIGN KEY([ChecklistTemplateId]) REFERENCES [TblChecklistTemplate](Id)
)
GO