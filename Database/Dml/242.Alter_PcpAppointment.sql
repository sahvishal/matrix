USE [$(dbName)]
Go

update pcpa set CreatedOn=e.EventDate from tblPcpAppointment pcpa 
		 inner join tblEventCustomers ec  on pcpa.EventCustomerId=ec.EventCustomerId 
		inner join tblEvents e on ec.EventId=e.EventId   where pcpa.CreatedOn is null 

Alter Table tblPcpAppointment ALTER COlUMN CreatedOn DateTime Not Null