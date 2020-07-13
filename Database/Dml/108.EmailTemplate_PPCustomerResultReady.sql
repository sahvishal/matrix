USE [$(dbName)]
Go

if not Exists (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnersCustomerResultReady')
begin
	INSERT INTO [TblEmailTemplate]
			   ([EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified],[TemplateType])
	VALUES
	('PhysicianPartnersCustomerResultReady','Physician Partners Customer Result Ready' 
		,'<table style="border-collapse: collapse; border-color: black; width: 600px;" border="1" cellspacing="0" cellpadding="0"><tbody><tr><td style="width: 600px; border: 1px;"><table style="font-family: Arial; width: 600px;" border="0" cellspacing="0" cellpadding="10"><tbody><tr><td style="height: 143px;"><table style="width: 600px;" border="0" cellspacing="0" cellpadding="10"><tbody><tr><td style="width: 250px;"><img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" alt="" /></td><td style="width: 350px;" align="right">Reasult Ready</td></tr></tbody></table></td></tr><tr><td>Dear @Model.CustomerName.ToString(),</td></tr><tr><td style="font-size: 13px; width: 600px;">We are pleased to announce that our board certified physicians have reviewed your screening results and they are now available through your primary care physician Dr. @(Model.PcpName).&nbsp;If you have not scheduled a follow-up appointment with your PCP please do so at this time.  Your PCP may be reached at @(Model.PcpPhone).</td></tr><tr><td style="font-size: 13px; width: 600px;">Thank you,<br />Camille Bagby<br />Customer Service Director</td></tr><tr><td><hr style="border: solid 1px #000000;" /></td></tr><tr><td class="normaltxt_pw" style="font-size: 12px;">&copy; <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl" target="_blank">Privacy Policy </a>and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl" target="_blank">Terms of Service</a><br />Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in an email.<br /><br /><br /><strong>@Model.EmailCommunicationBaseInfo.CompanyName</strong><br />@Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />@Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />@Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br /><span style="color: blue;">@Model.EmailCommunicationBaseInfo.PhoneTollFree</span> (Toll free)<br /><br /><strong>THIS IS AN AUTOMATED MESSAGE</strong> - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL. IF YOU WISH TO CONTACT HEALTHFAIR VIA EMAIL PLEASE USE <a href="mailto:INFO@HEALTHFAIR.COM">INFO@HEALTHFAIR.COM</a></td></tr></tbody></table></td></tr></tbody></table>'
		,getDate(),getDate(),174)

end
else
begin
	update TblEmailTemplate 
	set [EmailBody] = '<table style="border-collapse: collapse; border-color: black; width: 600px;" border="1" cellspacing="0" cellpadding="0"><tbody><tr><td style="width: 600px; border: 1px;"><table style="font-family: Arial; width: 600px;" border="0" cellspacing="0" cellpadding="10"><tbody><tr><td style="height: 143px;"><table style="width: 600px;" border="0" cellspacing="0" cellpadding="10"><tbody><tr><td style="width: 250px;"><img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" alt="" /></td><td style="width: 350px;" align="right">Reasult Ready</td></tr></tbody></table></td></tr><tr><td>Dear @Model.CustomerName.ToString(),</td></tr><tr><td style="font-size: 13px; width: 600px;">We are pleased to announce that our board certified physicians have reviewed your screening results and they are now available through your primary care physician Dr. @(Model.PcpName).&nbsp;If you have not scheduled a follow-up appointment with your PCP please do so at this time.  Your PCP may be reached at @(Model.PcpPhone).</td></tr><tr><td style="font-size: 13px; width: 600px;">Thank you,<br />Camille Bagby<br />Customer Service Director</td></tr><tr><td><hr style="border: solid 1px #000000;" /></td></tr><tr><td class="normaltxt_pw" style="font-size: 12px;">&copy; <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl" target="_blank">Privacy Policy </a>and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl" target="_blank">Terms of Service</a><br />Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in an email.<br /><br /><br /><strong>@Model.EmailCommunicationBaseInfo.CompanyName</strong><br />@Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />@Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />@Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br /><span style="color: blue;">@Model.EmailCommunicationBaseInfo.PhoneTollFree</span> (Toll free)<br /><br /><strong>THIS IS AN AUTOMATED MESSAGE</strong> - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL. IF YOU WISH TO CONTACT HEALTHFAIR VIA EMAIL PLEASE USE <a href="mailto:INFO@HEALTHFAIR.COM">INFO@HEALTHFAIR.COM</a></td></tr></tbody></table></td></tr></tbody></table>'
	where EmailTitle = 'PhysicianPartnersCustomerResultReady'
end
