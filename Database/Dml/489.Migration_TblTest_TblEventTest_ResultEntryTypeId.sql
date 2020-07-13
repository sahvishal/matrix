
 USE [$(dbname)]
 GO
 
DECLARE @ResultEntryTypeId BIGINT 
SET @ResultEntryTypeId = 420 

UPDATE TblTest SET ResultEntryTypeId = @ResultEntryTypeId  Where IsRecordable = 1	
UPDATE TblEventTest SET ResultEntryTypeId = @ResultEntryTypeId Where TestId in ( SELECT TestId FROM TblTest Where IsRecordable = 1 )

Go