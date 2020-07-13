
USE [$(dbName)]
Go

--City of Houston
Declare @AccountId bigint
set @AccountId = 887


update TblCustomerProfile 
set Tag = 'COH'
where CustomerID in
(
	select CustomerID from TblEventCustomers where EventID in 
	(
		select  EventID from TblEvents where EventID in
		(
			select EventID from TblEventAccount where AccountID = @AccountId
		)
		--and EventDate > GETDATE()-1
	)
	and AppointmentID is not null
)

