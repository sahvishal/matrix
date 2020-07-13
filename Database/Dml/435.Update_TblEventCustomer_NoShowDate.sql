USE [$(dbName)]

GO
UPDATE TblEventCustomers
SET NoShowDate = (select e.EventDate from TblEvents e where e.EventID=TblEventCustomers.EventID)
where TblEventCustomers.NoShow=1

GO