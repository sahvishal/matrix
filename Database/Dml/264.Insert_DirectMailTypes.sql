USE [$(dbName)]
Go


Insert into TblDirectMailType (Id,Name,Alias,DateCreated,CreatedBy)
	Values(1,'Customer Welcome Email','CustomerWelcomeEmail',GETDATE(),1)

Insert into TblDirectMailType (Id,Name,Alias,DateCreated,CreatedBy)
	Values(2,'Appointment Confirmation','AppointmentConfirmation',GETDATE(),1)

Insert into TblDirectMailType (Id,Name,Alias,DateCreated,CreatedBy)
	Values(3,'Screening Reminder Mail','ScreeningReminderMail',GETDATE(),1)

Insert into TblDirectMailType (Id,Name,Alias,DateCreated,CreatedBy)
	Values(4,'Evaluation Reminder','EvaluationReminder',GETDATE(),1)
