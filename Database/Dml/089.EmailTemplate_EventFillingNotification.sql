USE [$(dbName)]
Go


If Not Exists(select NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'EventFillingNotification')
begin
	insert Into TblNotificationType
		([NotificationTypeName] ,[NotificationTypeNameAlias] ,[Description] ,[DateCreated] ,[DateModified] ,[IsActive] ,[NoOfAttempts] ,[IsServiceEnabled] ,[IsQueuingEnabled] ,[ModifiedByOrgRoleUserId])
	values
		('Event Filling Notification' ,'EventFillingNotification' ,'Event Filling Notification' ,getdate() ,getdate() ,1 ,1 ,0 ,0 ,null)
end
else
begin
	Update TblNotificationType
	set [NotificationTypeName] = 'Event Filling Notification'
		,[NotificationTypeNameAlias] = 'EventFillingNotification'
		,[Description] = 'Event Filling Notification'
		,[DateCreated] = getdate()
		,[DateModified] = getdate()
		,[IsActive] = 1
		,[NoOfAttempts] = 1
		,[IsServiceEnabled] = 0 
		,[IsQueuingEnabled] = 0
		,[ModifiedByOrgRoleUserId] = null
	where NotificationTypeNameAlias = 'EventFillingNotification'
end

if not Exists (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'EventFillingNotification')
begin
	INSERT INTO [TblEmailTemplate]
			   ([EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
	VALUES
	('EventFillingNotification','Event Filling Notification' 
		,'<table style="border-collapse: collapse; border-color: black; width: 600px;" border="1" cellspacing="0" cellpadding="0">  <tbody>  <tr>  <td style="vertical-align: top;">  <table style="font-family: Arial; width: 600px;" border="0" cellspacing="0" cellpadding="2">  <tbody>  <tr>  <td style="height: 100px;">  <table style="width: 600px;" border="0" cellspacing="0" cellpadding="2">  <tbody>  <tr>  <td style="width: 250px;"><img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" alt="" /></td>  <td style="color: #47a942; width: 250px;" align="right">Event Filling Notification &nbsp;</td>  </tr>  </tbody>  </table>  </td>  </tr>  <tr>  <td class="normaltxt_pw" style="font-size: 13px;">Hi,<br /> <br /> The following event has reached its booking threshold level:<br /> <br />  <table border="1" cellspacing="0">  <tbody>  <tr>  <td>Event Id</td>  <td>@Model.EventId</td>  </tr>  <tr>  <td>Event Date</td>  <td>@Model.EventDate.ToString("MM/dd/yyyy")</td>  </tr>  <tr>  <td>Event Location</td>  <td>@Model.AddressOfVenue.ToString()</td>  </tr>  <tr>  <td>Pod(s)</td>  <td>@Model.Pods</td>  </tr>  <tr>  <td>Total Slots</td>  <td>@Model.TotalSlots</td>  </tr>  <tr>  <td>Available Slots</td>  <td>@Model.AvailableSlots</td>  </tr>  </tbody>  </table>  </td>  </tr>  <tr>  <td><hr style="float: left; height: 3px; width: 100%; color: #000; background-color: #000;" /></td>  </tr>  <tr>  <td class="normaltxt_pw" style="font-size: 12px;">- @Model.EmailCommunicationBaseInfo.CompanyName <span>Team</span></td>  </tr>  </tbody>  </table>  </td>  </tr>  </tbody>  </table>'
		,getDate(),getDate())

end
else
begin
	update TblEmailTemplate 
	set [EmailBody] = '<table style="border-collapse: collapse; border-color: black; width: 600px;" border="1" cellspacing="0" cellpadding="0">  <tbody>  <tr>  <td style="vertical-align: top;">  <table style="font-family: Arial; width: 600px;" border="0" cellspacing="0" cellpadding="2">  <tbody>  <tr>  <td style="height: 100px;">  <table style="width: 600px;" border="0" cellspacing="0" cellpadding="2">  <tbody>  <tr>  <td style="width: 250px;"><img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" alt="" /></td>  <td style="color: #47a942; width: 250px;" align="right">Event Filling Notification &nbsp;</td>  </tr>  </tbody>  </table>  </td>  </tr>  <tr>  <td class="normaltxt_pw" style="font-size: 13px;">Hi,<br /> <br /> The following event has reached its booking threshold level:<br /> <br />  <table border="1" cellspacing="0">  <tbody>  <tr>  <td>Event Id</td>  <td>@Model.EventId</td>  </tr>  <tr>  <td>Event Date</td>  <td>@Model.EventDate.ToString("MM/dd/yyyy")</td>  </tr>  <tr>  <td>Event Location</td>  <td>@Model.AddressOfVenue.ToString()</td>  </tr>  <tr>  <td>Pod(s)</td>  <td>@Model.Pods</td>  </tr>  <tr>  <td>Total Slots</td>  <td>@Model.TotalSlots</td>  </tr>  <tr>  <td>Available Slots</td>  <td>@Model.AvailableSlots</td>  </tr>  </tbody>  </table>  </td>  </tr>  <tr>  <td><hr style="float: left; height: 3px; width: 100%; color: #000; background-color: #000;" /></td>  </tr>  <tr>  <td class="normaltxt_pw" style="font-size: 12px;">- @Model.EmailCommunicationBaseInfo.CompanyName <span>Team</span></td>  </tr>  </tbody>  </table>  </td>  </tr>  </tbody>  </table>'
	where EmailTitle = 'EventFillingNotification'
end
