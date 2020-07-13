USE [$(dbName)]
Go

Create Table #MacroId (MacroId bigint)

insert into #MacroId
Select TemplateMacroId from TblEmailTemplateMacro where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'CustomerTaggedForDifferentTaggedEvent' )


delete from TblEmailTemplateMacro where EmailTemplateId in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'CustomerTaggedForDifferentTaggedEvent')

delete from TblTemplateMacro where Id in  (select MacroId from #MacroId) and Id Not in (select Id from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%')

drop table #MacroId


Declare @macroId bigint
Declare @EmailTemplateId bigint
select @EmailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'CustomerTaggedForDifferentTaggedEvent'
 
--CustomerId
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerId', '@Model.CustomerId')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 1  

--CustomerName
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerName', '@Model.CustomerName')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 1  


--PreviousEventId
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('PreviousEventId', '@Model.PreviousEventId')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 2  

--PreviousSponsor
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('PreviousSponsor', '@Model.PreviousSponser')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 3  

--PreviousEventDate
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('PreviousEventDate', '@Model.PreviousEventDate')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 4 


--PreviousTag
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('PreviousTag', '@Model.PreviousTag')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 5  

--NewEventId
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('NewEventId', '@Model.NewEventId')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 6  

--NewSponsor
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('NewSponsor', '@Model.NewSponser')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 7  

--NewEventDate
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('NewEventDate', '@Model.NewEventDate.ToString("MM/dd/yyyy")')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 8 


--NewTag
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('NewTag', '@Model.NewTag')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select @EmailTemplateId, @macroId, 9  


-- All Common

Insert Into TblEmailTemplateMacro (EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, A.Id, ((Select Max(Sequence) from TblEmailTemplateMacro where EmailTemplateId = X.EmailTemplateId) + (Row_Number() over(partition by EmailTemplateId order by A.Id asc))) as Sequence_Val  
from TblEmailTemplate X, 
(select * from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%') A 
where	EmailTitle = 'CustomerTaggedForDifferentTaggedEvent' 

