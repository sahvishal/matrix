USE [$(dbName)]
Go

Insert TblPcpAppointment (EventCustomerId,AppointmentOn) (select EventCustomerID,PcpAppointment from TblEventCustomers where PcpAppointment is Not null)


Alter Table TblEventCustomers Drop Column PcpAppointment