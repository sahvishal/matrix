USE [$(dbName)]
Go

Create Table #MacroId (MacroId bigint)

insert into #MacroId
Select TemplateMacroId from TblEmailTemplateMacro where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerSurveyEmailNotification' )


delete from TblEmailTemplateMacro where EmailTemplateId in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerSurveyEmailNotification')

delete from TblTemplateMacro where Id in  (select MacroId from #MacroId) and Id Not in (select Id from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%')

drop table #MacroId


Declare @macroId bigint

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerId', '@Model.CustomerId')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 1 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerSurveyEmailNotification' )

Set @macroId =0


Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('EventDate', '@Model.EventDate.ToString("M-dd-yyyy")')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 2 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerSurveyEmailNotification' )

Set @macroId =0


Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('EventId', '@Model.EventId')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 3 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerSurveyEmailNotification' )

Set @macroId =0

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('PodName', '@Model.PodName')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 4 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerSurveyEmailNotification' )


Set @macroId =0

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerName', '@Model.CustomerName.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 5 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerSurveyEmailNotification' )


Insert Into TblEmailTemplateMacro (EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, A.Id, ((Select Max(Sequence) from TblEmailTemplateMacro where EmailTemplateId = X.EmailTemplateId) + (Row_Number() over(partition by EmailTemplateId order by A.Id asc))) as Sequence_Val  
from TblEmailTemplate X, 
(select * from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%') A 
where	EmailTitle = 'PhysicianPartnerSurveyEmailNotification' 

