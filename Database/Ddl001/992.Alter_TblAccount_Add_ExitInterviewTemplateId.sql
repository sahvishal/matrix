USE [$(dbName)]
GO

alter table tblAccount 
Add ExitInterviewTemplateId bigint null,
	constraint FK_TblAccount_TblCheckListTemplate_ExitInterviewTemplateId foreign key (ExitInterviewTemplateId) references TblCheckListTemplate(Id)
	
GO