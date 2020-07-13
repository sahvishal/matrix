USE [$(dbName)]
Go

--update TblEmailTemplateMacro set Sequence = Sequence +2   where EmailTemplateId 
--in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'EmployeeWelcomeEmailWithPassword' ) and TemplateMacroId between 60 and 75

Declare @macroId bigint

Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('ResetLink', '@Model.ResetPasswordQueryString.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 3 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'EmployeeWelcomeEmailWithPassword' )


Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('UserId', '@Model.UserId.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 4 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'EmployeeWelcomeEmailWithPassword' )
 