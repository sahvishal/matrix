USE [$(dbName)]
Go

Create Table #MacroId (MacroId bigint)

insert into #MacroId
Select TemplateMacroId from TblEmailTemplateMacro where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPEmailNotification' )


delete from TblEmailTemplateMacro where EmailTemplateId in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPEmailNotification')

delete from TblTemplateMacro where Id in  (select MacroId from #MacroId) and Id Not in (select Id from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%')

drop table #MacroId


Declare @macroId bigint

 
--UserName
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('UserName', '@Model.UserName.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 2 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPEmailNotification' )

--OTP
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('Otp', '@Model.Otp.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 3 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPEmailNotification' )

--Expiration Minutes
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('Expiration_Minutes', '@Model.ExpirationMinutes.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 3 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPEmailNotification' )


-- All Common

Insert Into TblEmailTemplateMacro (EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, A.Id, ((Select Max(Sequence) from TblEmailTemplateMacro where EmailTemplateId = X.EmailTemplateId) + (Row_Number() over(partition by EmailTemplateId order by A.Id asc))) as Sequence_Val  
from TblEmailTemplate X, 
(select * from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%') A 
where	EmailTitle = 'LoginOTPEmailNotification' 

