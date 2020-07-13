USE [$(dbName)]
Go

Create Table #MacroId (MacroId bigint)

insert into #MacroId
Select TemplateMacroId from TblEmailTemplateMacro where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'TestUpsellNotification' )

--select MacroId from #MacroId

delete from TblEmailTemplateMacro where EmailTemplateId in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'TestUpsellNotification')

delete from TblTemplateMacro where Id in  (select MacroId from #MacroId) and Id Not in (select Id from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%')

drop table #MacroId

Declare @macroId bigint

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('Customer_Name', '@Model.CustomerName')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 1 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'TestUpsellNotification' )


Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('Upsell_Tests', '@if(Model.Tests !=null && Model.Tests.Count() > 0)                        {                        <table border="1" cellpadding="5px" cellspacing="0px"  width="580px">                            @foreach(var test in Model.Tests)                            {                                <tr>                                    <td style="width:30%;">                                        @test.Name                                    </td>                                    <td style="width:70%;">                                        @test.Description                                    </td>                                </tr>                            }                        </table>                         }')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 2 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'TestUpsellNotification' )

---------------------------------------------------------------------------------------------------------------------------------

Insert Into TblEmailTemplateMacro (EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, A.Id, ((Select Max(Sequence) from TblEmailTemplateMacro where EmailTemplateId = X.EmailTemplateId) + (Row_Number() over(partition by EmailTemplateId order by A.Id asc))) as Sequence_Val  
from TblEmailTemplate X, 
(select * from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%') A 
where EmailTitle = 'TestUpsellNotification' 
	
