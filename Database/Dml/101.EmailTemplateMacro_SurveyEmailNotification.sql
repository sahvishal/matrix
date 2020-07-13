USE [$(dbName)]
Go

Create Table #MacroId (MacroId bigint)

insert into #MacroId
Select TemplateMacroId from TblEmailTemplateMacro where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )


delete from TblEmailTemplateMacro where EmailTemplateId in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification')

delete from TblTemplateMacro where Id in  (select MacroId from #MacroId) and Id Not in (select Id from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%')

drop table #MacroId


Declare @macroId bigint

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerId', '@Model.CustomerId')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 1 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )

Set @macroId =0


Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('EventDate', '@Model.EventDate.ToString("M-dd-yyyy")')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 2 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )

Set @macroId =0


Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('EventId', '@Model.EventId')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 3 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )

Set @macroId =0

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('PodName', '@Model.PodName')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 4 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )

Set @macroId =0

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerEmail', '@Model.CustomerEmail.ToLower()')

Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 5 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )

Set @macroId =0

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerFirstName', '@Model.CustomerName.FirstName.Replace("''","").ToLower()')

Set @macroId = Scope_Identity()
Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 6 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )

Set @macroId =0

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerLastName', '@Model.CustomerName.LastName.Replace("''","").ToLower()')


Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 7 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )

Insert Into TblTemplateMacro (IdentifierName, CodeString)
values ('CustomerName', '@Model.CustomerName.ToString()')

Set @macroId =0
Set @macroId = Scope_Identity()

Insert Into TblEmailTemplateMacro(EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, @macroId, 8 from TblEmailTemplate where EmailTemplateId 
in (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification' )


Insert Into TblEmailTemplateMacro (EmailTemplateId, TemplateMacroId, Sequence)
Select EmailTemplateId, A.Id, ((Select Max(Sequence) from TblEmailTemplateMacro where EmailTemplateId = X.EmailTemplateId) + (Row_Number() over(partition by EmailTemplateId order by A.Id asc))) as Sequence_Val  
from TblEmailTemplate X, 
(select * from TblTemplateMacro where CodeString like '%@Model.EmailCommunicationBaseInfo%' and IdentifierName like 'Company%') A 
where	EmailTitle = 'SurveyEmailNotification' 


update TblEmailTemplate 
set EmailBody = '<table style="border-collapse: collapse; border-color: black;" border="1" cellpadding="0"    cellspacing="0" width="600">    <tr>        <td style="width: 600px; border: 1px">            <table style="font-family: Arial" border="0" cellpadding="10" cellspacing="0" width="600">                <tr>                    <td style="height: 143px">                        <table border="0" cellpadding="10" cellspacing="0" width="600">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" alt="" />                                </td>                                <td style="width: 350px" align="right">                                    HealthFair Satisfaction Survey                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td>                        Dear @Model.CustomerName.ToString(),                    </td>                </tr>                <tr>                    <td style="font-size: 13px; width: 600px">                        In an effort to better serve our customers, @Model.EmailCommunicationBaseInfo.CompanyName                        is conducting a customer survey. Your input can help us better serve you. We estimate                        that it will take you less than 5 minutes to complete the survey.                        <br />                        <br />                        Simply click on the link below to access the survey:                        <br />                        <a href=''https://www.research.net/s/healthfaircustomersurvey?id=@Model.CustomerId&eid=@Model.EventId&pod=@Model.PodName&edate=@Model.EventDate.ToString("M-dd-yyyy")&c=@Model.CustomerName.FirstName.Replace("''","").ToLower(),@Model.CustomerName.LastName.Replace("''","").ToLower(),@Model.CustomerEmail.ToLower()''>                            https://www.research.net/s/healthfaircustomersurvey?id=@Model.CustomerId&eid=@Model.EventId&pod=@Model.PodName&edate=@Model.EventDate.ToString("M-dd-yyyy")&c=@Model.CustomerName.FirstName.Replace("''","").ToLower(),@Model.CustomerName.LastName.Replace("''","").ToLower(),@Model.CustomerEmail.ToLower()                        </a>                    </td>                </tr>                <tr>                    <td style="font-size: 13px; width: 600px">                        Thank you,                        <br />                        Camille Bagby                        <br />                        Customer Service Director                    </td>                </tr>                <tr>                    <td>                        <hr style="border: solid 1px #000000;" />                    </td>                </tr>                <tr>                    <td class="normaltxt_pw" style="font-size: 12px;">                        &copy; <a target="_blank" href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">                            Privacy Policy </a>and <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">                                Terms of Service</a>                        <br />                        Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your                        password or creditcard number in an email.<br />                        <br />                        This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you                        or someone on your behalf registered online at <a target="_blank" href="@Model.EmailCommunicationBaseInfo.SiteUrl">                            @Model.EmailCommunicationBaseInfo.SiteUrl.</a>                        <br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp;                        @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        <span style="color: Blue;">@Model.EmailCommunicationBaseInfo.PhoneTollFree</span>                        (Toll free)                        <br />                        <br />                        <b>THIS IS AN AUTOMATED MESSAGE</b> - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL.                        IF YOU WISH TO CONTACT HEALTHFAIR VIA EMAIL PLEASE USE <a href="mailto:INFO@HEALTHFAIR.COM">                            INFO@HEALTHFAIR.COM</a>                    </td>                </tr>            </table>        </td>    </tr></table>'
where EmailTitle = 'SurveyEmailNotification'

