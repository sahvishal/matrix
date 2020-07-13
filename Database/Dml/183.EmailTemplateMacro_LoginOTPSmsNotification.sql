USE [$(dbName)]
Go

Create Table #MacroId (MacroId bigint)

insert into #MacroId
Select TemplateMacroId from TblEmailTemplateMacro where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPSmsNotification' )


delete from TblEmailTemplateMacro where EmailTemplateId in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPSmsNotification')

delete from TblTemplateMacro where Id in  (select MacroId from #MacroId)  

drop table #MacroId


Declare @macroId bigint

 
--OTP
Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('Otp', '@Model.Otp.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 1 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPSmsNotification' )

 
