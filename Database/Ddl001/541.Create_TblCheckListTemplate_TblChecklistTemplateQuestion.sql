use [$(dbName)]
Go


CREATE TABLE TblCheckListTemplate
(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(255) NULL,
	HealthPlanId BIGINT NULL,		
	IsActive BIT NOT NULL CONSTRAINT DF_TblCheckListTemplate_IsActive DEFAULT(1),
	IsPublished BIT NOT NULL CONSTRAINT DF_TblCheckListTemplate_IsPublished DEFAULT(0),
	DateCreated DATETIME NOT NULL CONSTRAINT DF_TblCheckListTemplate_DateCreated DEFAULT GETDATE(),
	DateModified DATETIME NULL,
	CreatedBy BIGINT NOT NULL,
	ModifiedBy BIGINT NULL,
	CONSTRAINT PK_TblCheckListTemplate PRIMARY KEY (Id),
	CONSTRAINT FK_TblCheckListTemplate_TblOrganizationRoleUser_CreatedBy FOREIGN KEY(CreatedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserId),
	CONSTRAINT FK_TblCheckListTemplate_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY(ModifiedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserId)
)
GO

CREATE TABLE TblCheckListTemplateQuestion
(
	TemplateId BIGINT NOT NULL,
	QuestionId BIGINT NOT NULL,
	CONSTRAINT PK_TblCheckListTemplateQuestion PRIMARY KEY (TemplateId, QuestionId),
	CONSTRAINT FK_TblCheckListTemplateQuestion_TblCheckListTemplate FOREIGN KEY(TemplateId) REFERENCES TblCheckListTemplate(Id),
	CONSTRAINT FK_TblCheckListTemplateQuestion_TblCheckListQuestion FOREIGN KEY(QuestionId) REFERENCES TblCheckListQuestion(Id)
)
GO