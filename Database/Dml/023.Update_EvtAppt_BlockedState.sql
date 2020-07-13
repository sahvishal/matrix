USE [$(dbName)]
Go

Update TblEventAppointment Set Status = 3 where isnull(ScheduledbyOrgRoleUserId , 0) > 0 and Subject = 'Blocked' and AppointmentId not in (Select distinct AppointmentId from  TblEventCustomers where appointmentId is not null)