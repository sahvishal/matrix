USE [$(dbName)]
Go

Declare @NotificationTypeId int
select @NotificationTypeId = NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'EmployeeWelcomeEmailWithPassword'

if not Exists (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'EmployeeWelcomeEmailWithPassword')
begin
	INSERT INTO [TblEmailTemplate]
			   ([EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified],[TemplateType],[NotificationTypeId])
	VALUES
	('EmployeeWelcomeEmailWithPassword','Employee Welcome Email With Password Reset Link' 
		,'<table style="font-family: Verdana, Arial; color: gray; font-size: 14;">
<tbody>
<tr>
<td>Dear @Model.FullName,<br /> <br /><span style="font-size: medium;"> Your account has been setup with <strong>@Model.EmailCommunicationBaseInfo.ProductName</strong> </span><br />  <br /> Please confirm joining the @Model.EmailCommunicationBaseInfo.CompanyName by logging in the Application useing the link given below:<br /> This link is for single time use</p>  <p> <a target="_blank" href="@Model.EmailCommunicationBaseInfo.AppUrl/App/ResetPassword.aspx?UserID=@Model.UserId&amp;AuthStr=@Model.ResetPasswordQueryString">@Model.EmailCommunicationBaseInfo.AppUrl/App/ResetPassword.aspx?UserID=@Model.UserId&amp;AuthStr=@Model.ResetPasswordQueryString</a><br /> <br /> (If the link is not clickable, please copy and paste it into your browser&rsquo;s address field.)<br /> <br /> If you ever need to contact us, we&rsquo;are just an email away. <br /> <br /> You can reach us at @Model.EmailCommunicationBaseInfo.SupportEmail.<br /> <br /> <span style="font-size: xx-small;">&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl"> Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl"> Terms of Service</a></span> <br /> <br /> <span style="font-size: xx-small;">Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in an email.</span><br /> </td>
</tr>
</tbody>
</table>'
		,getDate(),getDate(),174,@NotificationTypeId)

end
else
begin
	update TblEmailTemplate 
	set [EmailBody] = '<table style="font-family: Verdana, Arial; color: gray; font-size: 14;">
<tbody>
<tr>
<td>Dear @Model.FullName,<br /> <br /><span style="font-size: medium;"> Your account has been setup with <strong>@Model.EmailCommunicationBaseInfo.ProductName</strong> </span><br />  <br /> Please confirm joining the @Model.EmailCommunicationBaseInfo.CompanyName by logging in the Application useing the link given below:<br /> This link is for single time use</p>  <p> <a target="_blank" href="@Model.EmailCommunicationBaseInfo.AppUrl/App/ResetPassword.aspx?UserID=@Model.UserId&amp;AuthStr=@Model.ResetPasswordQueryString">@Model.EmailCommunicationBaseInfo.AppUrl/App/ResetPassword.aspx?UserID=@Model.UserId&amp;AuthStr=@Model.ResetPasswordQueryString</a><br /> <br /> (If the link is not clickable, please copy and paste it into your browser&rsquo;s address field.)<br /> <br /> If you ever need to contact us, we&rsquo;are just an email away. <br /> <br /> You can reach us at @Model.EmailCommunicationBaseInfo.SupportEmail.<br /> <br /> <span style="font-size: xx-small;">&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl"> Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl"> Terms of Service</a></span> <br /> <br /> <span style="font-size: xx-small;">Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in an email.</span><br /> </td>
</tr>
</tbody>
</table>'
	,[EmailSubject] = 'Employee Welcome Email With Password Reset Link'
	where EmailTitle = 'EmployeeWelcomeEmailWithPassword'
end
