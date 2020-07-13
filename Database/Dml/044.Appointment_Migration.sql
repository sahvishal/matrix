
USE [$(dbName)]
Go

begin try

Begin Tran

delete from TblEventAppointment where EventId not in (select EventId from TblEvents)

Update TblEventAppointment
set StartTime = Cast(Convert(varchar,StartDate, 101) + ' ' + Convert(varchar,StartTime, 108) as DateTime)
	,EndTime = Cast(Convert(varchar,EndDate, 101) + ' ' + Convert(varchar,EndTime, 108) as DateTime)


SET IDENTITY_INSERT TblEventSchedulingSlot ON

Insert Into TblEventSchedulingSlot (SlotId ,EventId ,StartTime ,EndTime ,Reason ,DateCreated ,DateModified ,Status)
select AppointmentId ,EventId ,StartTime ,EndTime ,Reason ,DateCreated ,DateModified ,Status
from TblEventAppointment

SET IDENTITY_INSERT TblEventSchedulingSlot OFF

Insert Into TblEventSlotAppointment (SlotId ,AppointmentId)
Select AppointmentId ,AppointmentId from TblEventAppointment where AppointmentId in (select IsNull(AppointmentId,0) from TblEventCustomers) 

delete from TblEventAppointment where AppointmentId not in (select IsNull(AppointmentId,0) from TblEventCustomers) 


Alter Table TblEventAppointment Drop Column StartDate
Alter Table TblEventAppointment Drop Column EndDate
Alter Table TblEventAppointment Drop Column [Subject]
Alter Table TblEventAppointment Drop Column Reason
Alter Table TblEventAppointment Drop DF__TblEventA__Statu__75785BC3
Alter Table TblEventAppointment Drop Column [Status]
--Alter Table TblEventAppointment Drop Column DateModified

Commit Tran

end try
begin catch
	IF @@TRANCOUNT > 0
		ROLLBACK TRAN
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
		 @ErrSeverity = ERROR_SEVERITY()	
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
end catch