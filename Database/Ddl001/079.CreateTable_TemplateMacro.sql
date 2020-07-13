USE [$(dbName)]
Go

Create Table TblTemplateMacro(
	Id bigint not null identity(1,1) constraint PK_TemplateMacro Primary Key,
	IdentifierName varchar(200) not null constraint UQ_IdentifierName_TemplateMacro Unique,
	CodeString varchar(max) not null
)

Alter Table TblEmailTemplate Drop Constraint PK_TblEmailTemplate_1

Alter Table TblEmailTemplate Add Constraint PK_EmailTemplate Primary Key(EmailTemplateId) 

Alter Table TblEmailTemplate Add Constraint UQ_Title_EmailTemplate Unique(EmailTitle) 

Alter Table TblEmailTemplate Add ModifiedByOrgRoleUserId bigint null

Alter Table TblEmailTemplate Add Constraint FK_EmailTemplate_OrganizationRoleUser Foreign Key(ModifiedByOrgRoleUserId) references TblOrganizationRoleUser(OrganizationRoleUserId) 


Create Table TblEmailTemplateMacro(
	EmailTemplateId int not null Constraint FK_EmailTemplate_EmailTemplateMacro Foreign Key references TblEmailTemplate(EmailTemplateId),
	TemplateMacroId bigint not null Constraint FK_TemplateMacro_EmailTemplateMacro Foreign Key references TblTemplateMacro(Id),
	Constraint PK_EmailTemplateMacro Primary Key(EmailTemplateId, TemplateMacroId)
)