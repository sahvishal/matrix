USE [$(dbName)]
Go

Declare @NotificationTypeId int
select @NotificationTypeId = NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'LoginOTPEmailNotification'

if not Exists (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPEmailNotification')
begin
	INSERT INTO [TblEmailTemplate]
			   ([EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified],[TemplateType],[NotificationTypeId])
	VALUES
	('LoginOTPEmailNotification','Login OTP Email Notification' 
		,'<table style="border-collapse: collapse; border-color: black; width: 600px;" border="1" cellspacing="0" cellpadding="0">  <tbody>  <tr>  <td style="width: 600px; border: 1px;">  <table style="font-family: Arial; width: 600px;" border="0" cellspacing="0" cellpadding="10">  <tbody>  <tr>  <td style="height: 143px;">  <table style="width: 600px;" border="0" cellspacing="0" cellpadding="10">  <tbody>  <tr>  <td style="width: 250px;"><img src="@Model.EmailCommunicationBaseInfo.AppUrl/Config/Content/Images/Logo-Small-160x60.gif" alt="" /></td>  <td style="color: #5db3ed; width: 350px;" align="right">One Time Passowrd </td>  </tr>  </tbody>  </table>  </td>  </tr>  <tr>  <td style="font-size: 13px; width: 600px;">Dear @Model.UserName.ToString(),<br /> <br /> To complete the login process use the OTP:@Model.Otp.ToString()<br />&nbsp; <br /> This OTP will Expire Within @Model.ExpirationMinutes.ToString() minute(s). <br /> <br /> If you ever need to contact us, we&rsquo;re just an email or a phone call away! You may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail"> @Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free).<br /> <br /> <br /> - The @Model.EmailCommunicationBaseInfo.CompanyName Team</td>  </tr>  <tr>  <td><hr style="border: 1px; color: black;" /></td>  </tr>  <tr>  <td style="font-size: 12px; color: gray;">&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl" target="_blank"> Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl" target="_blank"> Terms of Service</a><br /> Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in an email.<br /> <br /> This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered online at <a href="@Model.EmailCommunicationBaseInfo.SiteUrl" target="_blank"> @Model.EmailCommunicationBaseInfo.SiteUrl</a><br /> <br /> <strong>@Model.EmailCommunicationBaseInfo.CompanyName</strong><br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br /> @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free) <br /> <br /> <strong>THIS IS AN AUTOMATED MESSAGE</strong> - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL. IF YOU WISH TO CONTACT HEALTHFAIR VIA EMAIL PLEASE USE <a href="mailto:INFO@HEALTHFAIR.COM">INFO@HEALTHFAIR.COM</a></td>  </tr>  </tbody>  </table>  </td>  </tr>  </tbody>  </table>'
		,getDate(),getDate(),174,@NotificationTypeId)

end
else
begin
	update TblEmailTemplate 
	set [EmailBody] = '<table style="border-collapse: collapse; border-color: black; width: 600px;" border="1" cellspacing="0" cellpadding="0">  <tbody>  <tr>  <td style="width: 600px; border: 1px;">  <table style="font-family: Arial; width: 600px;" border="0" cellspacing="0" cellpadding="10">  <tbody>  <tr>  <td style="height: 143px;">  <table style="width: 600px;" border="0" cellspacing="0" cellpadding="10">  <tbody>  <tr>  <td style="width: 250px;"><img src="@Model.EmailCommunicationBaseInfo.AppUrl/Config/Content/Images/Logo-Small-160x60.gif" alt="" /></td>  <td style="color: #5db3ed; width: 350px;" align="right">One Time Passowrd </td>  </tr>  </tbody>  </table>  </td>  </tr>  <tr>  <td style="font-size: 13px; width: 600px;">Dear @Model.UserName.ToString(),<br /> <br /> To complete the login process use the OTP:@Model.Otp.ToString()<br />&nbsp; <br /> This OTP will Expire Within @Model.ExpirationMinutes.ToString() minute(s). <br /> <br /> If you ever need to contact us, we&rsquo;re just an email or a phone call away! You may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail"> @Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free).<br /> <br /> <br /> - The @Model.EmailCommunicationBaseInfo.CompanyName Team</td>  </tr>  <tr>  <td><hr style="border: 1px; color: black;" /></td>  </tr>  <tr>  <td style="font-size: 12px; color: gray;">&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl" target="_blank"> Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl" target="_blank"> Terms of Service</a><br /> Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in an email.<br /> <br /> This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered online at <a href="@Model.EmailCommunicationBaseInfo.SiteUrl" target="_blank"> @Model.EmailCommunicationBaseInfo.SiteUrl</a><br /> <br /> <strong>@Model.EmailCommunicationBaseInfo.CompanyName</strong><br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br /> @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free) <br /> <br /> <strong>THIS IS AN AUTOMATED MESSAGE</strong> - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL. IF YOU WISH TO CONTACT HEALTHFAIR VIA EMAIL PLEASE USE <a href="mailto:INFO@HEALTHFAIR.COM">INFO@HEALTHFAIR.COM</a></td>  </tr>  </tbody>  </table>  </td>  </tr>  </tbody>  </table>'
	where EmailTitle = 'LoginOTPEmailNotification'
end