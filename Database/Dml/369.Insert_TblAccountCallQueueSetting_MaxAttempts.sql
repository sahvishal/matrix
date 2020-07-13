USE [$(dbname)]
GO

--DELETE FROM TblAccountCallQueueSetting WHERE SuppressionTypeID = 347

DECLARE @MaxCallAttempt INT = 10
DECLARE @SuppressionTypeId BIGINT = 347


DECLARE AccountCursor CURSOR FOR select AccountID from TblAccount with(nolock) where IsHealthPlan=1
DECLARE @AccountId BIGINT
OPEN AccountCursor

FETCH NEXT FROM AccountCursor INTO @AccountId

WHILE @@FETCH_STATUS = 0  
BEGIN  

		--call queue cursor
		DECLARE CallQueueCursor CURSOR FOR select CallQueueId, Category from TblCallQueue where IsActive = 1 and IsHealthPlan = 1
		DECLARE @CallQueueId BIGINT
		DECLARE @CallQueueCategory varchar(20)
		OPEN CallQueueCursor

		FETCH NEXT FROM CallQueueCursor INTO @CallQueueId, @CallQueueCategory

		WHILE @@FETCH_STATUS = 0  
		BEGIN  
			IF(@CallQueueCategory = 'MailRound' OR @CallQueueCategory = 'FillEventsHealthPlan' OR @CallQueueCategory = 'LanguageBarrier')
			BEGIN
				INSERT INTO TblAccountCallQueueSetting (AccountID, CallQueueID,SuppressionTypeID,NoOfDays, DateCreated, IsActive)
				VALUES(@AccountId, @CallQueueId, @SuppressionTypeId, @MaxCallAttempt, GETDATE(), 1)					    
			END

		FETCH NEXT FROM CallQueueCursor INTO @CallQueueId,@CallQueueCategory
		END;
		CLOSE CallQueueCursor;
		DEALLOCATE CallQueueCursor;
		--end call queue cursor

       FETCH NEXT FROM AccountCursor INTO  @AccountId
END
CLOSE AccountCursor
DEALLOCATE AccountCursor
GO
