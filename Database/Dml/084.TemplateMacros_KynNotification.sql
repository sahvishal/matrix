USE [$(dbName)]
Go

Create Table #MacroId (MacroId bigint)

insert into #MacroId
Select TemplateMacroId from TblEmailTemplateMacro where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'KynFirstNotification' or EmailTitle = 'KynSecondNotification' )

--select MacroId from #MacroId

delete from TblEmailTemplateMacro where EmailTemplateId in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'KynFirstNotification' or EmailTitle = 'KynSecondNotification')

delete from TblTemplateMacro where Id in  (select MacroId from #MacroId) and Id Not in (select Id from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%')

drop table #MacroId

Declare @macroId bigint

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('Customer_Name', '@Model.CustomerName')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 1 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'KynFirstNotification' or EmailTitle = 'KynSecondNotification' )


Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('EventDate', '@Model.EventDate.ToString("MM/dd/yyyy")')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 2 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'KynFirstNotification' or EmailTitle = 'KynSecondNotification' )

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('EventLocation', '@Model.AddressOfVenue.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 3 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'KynFirstNotification' or EmailTitle = 'KynSecondNotification' )

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('AppointmentTime_12HOUR-FORMAT', '@Model.AppointmentTime.ToString("hh:mm tt")')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 4 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'KynFirstNotification' or EmailTitle = 'KynSecondNotification' )

---------------------------------------------------------------------------------------------------------------------------------

Insert Into TblEmailTemplateMacro (EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, A.Id, ((Select Max(Sequence) from TblEmailTemplateMacro where EmailTemplateId = X.EmailTemplateId) + (Row_Number() over(partition by EmailTemplateId order by A.Id asc))) as Sequence_Val  
from TblEmailTemplate X, 
(select * from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%') A 
where EmailTitle = 'KynFirstNotification' or EmailTitle = 'KynSecondNotification'
	
