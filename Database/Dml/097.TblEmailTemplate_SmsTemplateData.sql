USE [$(dbName)]
Go

delete from TblEmailTemplateMacro where EmailTemplateId in 
(
	select EmailTemplateId from TblEmailTemplate where EmailTitle in ('AppointmentReminder', 'AppointmentConfirmation')
)

delete from TblEmailTemplate where EmailTitle in ('AppointmentReminder', 'AppointmentConfirmation')

Declare @macro1 bigint
Declare @macro2 bigint
Declare @macro3 bigint
Declare @macro4 bigint

insert into TblTemplateMacro(IdentifierName,CodeString) values('CustomerName','@Model.CustomerName')
Set @macro1 = SCOPE_IDENTITY()
insert into TblTemplateMacro(IdentifierName,CodeString) values('AppointmentTime_12HOUR-FORMAT','@Model.AppointmentTime.ToString("hh:mm tt")')
Set @macro2 = SCOPE_IDENTITY()
insert into TblTemplateMacro(IdentifierName,CodeString) values('EventDate','@Model.EventDate.ToString("MM/dd/yyyy")')
Set @macro3 = SCOPE_IDENTITY()
insert into TblTemplateMacro(IdentifierName,CodeString) values('EventLocation','@Model.AddressOfVenue.ToString()')
Set @macro4 = SCOPE_IDENTITY()

Declare @LastID bigint

insert into TblEmailTemplate(EmailTitle,EmailSubject,EmailBody,DateCreated,DateModified,ModifiedByOrgRoleUserId,TemplateType)
values('AppointmentReminder','Appointment Reminder','Dear @Model.CustomerName,You have an appointment for your health screening at @Model.AppointmentTime.ToString("hh:mm tt") on @Model.EventDate.ToString("MM/dd/yyyy") at @Model.AddressOfVenue.ToString(). For any further info call 1855-755-8378.',GETDATE(),GETDATE(),null,175);

set @LastID=SCOPE_IDENTITY()

insert into TblEmailTemplateMacro(EmailTemplateId,TemplateMacroId,Sequence,ParameterValue)
values(@LastID,@macro1,1,null)
insert into TblEmailTemplateMacro
values(@LastID,@macro2,2,null)
insert into TblEmailTemplateMacro
values(@LastID,@macro3,3,null)
insert into TblEmailTemplateMacro
values(@LastID,@macro4,4,null)


insert into TblEmailTemplate(EmailTitle,EmailSubject,EmailBody,DateCreated,DateModified,ModifiedByOrgRoleUserId,TemplateType)
values('AppointmentConfirmation','Appointment Confirmation','Dear @Model.CustomerName,Your appointment on @Model.EventDate.ToString("MM/dd/yyyy") at @Model.AppointmentTime.ToString("hh:mm tt") at @Model.AddressOfVenue.ToString() for your health checkup with HealthFair is confirmed. For any further info call 1855-755-8378.',GETDATE(),GETDATE(),null,175);

set @LastID=SCOPE_IDENTITY()

insert into TblEmailTemplateMacro(EmailTemplateId,TemplateMacroId,Sequence,ParameterValue)
values(@LastID,@macro1,1,null)
insert into TblEmailTemplateMacro
values(@LastID,@macro2,2,null)
insert into TblEmailTemplateMacro
values(@LastID,@macro3,3,null)
insert into TblEmailTemplateMacro
values(@LastID,@macro4,4,null)

