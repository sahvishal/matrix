USE [$(dbName)]
Go
 
Declare @macroId bigint

Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('ResetLink', '@Model.ResetPasswordQueryString.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 3 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'CustomerWelcomeEmailWithPassword' )


Set @macroId =0  

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('UserId', '@Model.UserId.ToString()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 4 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'CustomerWelcomeEmailWithPassword' )
 