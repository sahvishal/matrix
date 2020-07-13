
USE [$(dbName)]
Go
Update TblAccount Set EventLockDaysCount= 1 where EventLockDaysCount is null and LockEvent = 1

  

 