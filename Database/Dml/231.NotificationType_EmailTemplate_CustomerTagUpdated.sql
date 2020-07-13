
USE [$(dbName)]
Go
Update TblNotificationType
set [NotificationTypeName] = 'Customer Tag Updated'
	,[NotificationTypeNameAlias] = 'CustomerTagUpdated'
	,[Description] = 'Customer Tag Updated'
	,[DateCreated] = getdate()
	,[DateModified] = getdate()
	,[IsActive] = 1
	,[NoOfAttempts] = 1
	,[IsServiceEnabled] = 1 
	,[IsQueuingEnabled] = 1
	,[ModifiedByOrgRoleUserId] = null
where NotificationTypeNameAlias = 'CustomerTaggedForDifferentTaggedEvent'

GO

update TblEmailTemplate 
set EmailTitle = 'CustomerTagUpdated'
,[EmailSubject] = 'Customer Tag Updated'
where EmailTitle = 'CustomerTaggedForDifferentTaggedEvent'


update TblEmailTemplate 
set [EmailBody] = '<table style="border-collapse: collapse; border-color: black; width: 600px;" border="1" cellspacing="0" cellpadding="0">  <tbody>  <tr>  <td style="width: 600px; border: 1px;">  <table style="font-family: Arial; width: 600px;" border="0" cellspacing="0" cellpadding="10">  <tbody>  <tr>  <td style="height: 143px;">  <table style="width: 600px;" border="0" cellspacing="0" cellpadding="10">  <tbody>  <tr>  <td style="width: 250px;"><img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" alt="" /></td>  <td style="color: #5db3ed; width: 350px;" align="right">Customer Tag Updated</td>  </tr>  </tbody>  </table>  </td>  </tr>  <tr>  <td style="font-size: 13px; width: 600px;">  <p>Hi,</p>  <p>Tag has been updated for Customer : <strong>@Model.CustomerName</strong> <strong>(@Model.CustomerId)</strong><br /> <br /><br /></p>  <table style="width: 500px; text-align: left;" border="1" cellspacing="0" cellpadding="5">  <tbody>  <tr><th style="width: 30%;">&nbsp;</th><th style="width: 35%;">Previous Event</th><th style="width: 35%;">New Event</th></tr>  <tr>  <td>Event Id</td>  <td>@Model.PreviousEventId</td>  <td>@Model.NewEventId</td>  </tr>  <tr>  <td>Event Date</td>  <td>@Model.PreviousEventDate</td>  <td>@Model.NewEventDate.ToString("MM/dd/yyyy")</td>  </tr>  <tr>  <td>Sponsor</td>  <td>@Model.PreviousSponser</td>  <td>@Model.NewSponser</td>  </tr>  <tr>  <td>TAG</td>  <td>@Model.PreviousTag</td>  <td>@Model.NewTag</td>  </tr>  </tbody>  </table>  <br /> &nbsp;<br /> <br /> - The @Model.EmailCommunicationBaseInfo.CompanyName Team</td>  </tr>  <tr>  <td><hr style="border: 1px; color: black;" /></td>  </tr>  <tr>  <td style="font-size: 12px; color: gray;">&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl" target="_blank">Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl" target="_blank">Terms of Service</a><br /> Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in an email.<br /> <br /> This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered online at <a href="@Model.EmailCommunicationBaseInfo.SiteUrl" target="_blank">@Model.EmailCommunicationBaseInfo.SiteUrl</a><br /> <br /> <strong>@Model.EmailCommunicationBaseInfo.CompanyName</strong><br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br /> @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br /> @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free) <br /> <br /> <strong>THIS IS AN AUTOMATED MESSAGE</strong> - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL. IF YOU WISH TO CONTACT HEALTHFAIR VIA EMAIL PLEASE USE <a href="mailto:INFO@HEALTHFAIR.COM">INFO@HEALTHFAIR.COM</a></td>  </tr>  </tbody>  </table>  </td>  </tr>  </tbody>  </table>'
where EmailTitle = 'CustomerTagUpdated'

