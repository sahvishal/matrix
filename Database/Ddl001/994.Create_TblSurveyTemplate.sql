use [$(dbName)]
Go


CREATE TABLE TblSurveyTemplate
(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(255) NULL,
	IsActive BIT NOT NULL CONSTRAINT DF_TblSurveyTemplate_IsActive DEFAULT(1),
	IsPublished BIT NOT NULL CONSTRAINT DF_TblSurveyTemplate_IsPublished DEFAULT(0),
	DateCreated DATETIME NOT NULL CONSTRAINT DF_TblSurveyTemplate_DateCreated DEFAULT GETDATE(),
	DateModified DATETIME NULL,
	CreatedBy BIGINT NOT NULL,
	ModifiedBy BIGINT NULL,
	IsDefault BIT NOT NULL CONSTRAINT DF_TblSurveyTemplate_IsDefault DEFAULT(0)
	CONSTRAINT PK_TblSurveyTemplate PRIMARY KEY (Id),
	CONSTRAINT FK_TblSurveyTemplate_TblOrganizationRoleUser_CreatedBy FOREIGN KEY(CreatedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserId),
	CONSTRAINT FK_TblSurveyTemplate_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY(ModifiedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserId)
)
GO
