USE [$(dbname)]
GO

--DELETE FROM TblAccountCallQueueSetting

DECLARE @MailRoundLeftVoiceMailDefault INT = 3;
DECLARE @MailRoundAllCallDefault INT = 5;
DECLARE @FillEventAllCallDefault INT = 3;
DECLARE @RefusedCustomerDefault INT = 14;
DECLARE @DefaultValueForAll INT = 3;
DECLARE @FillEventRefusedCustomerDefault INT = 3;


DECLARE AccountCursor CURSOR FOR select AccountID from TblAccount with(nolock) where IsHealthPlan=1 ;
DECLARE @AccountId BIGINT;
OPEN AccountCursor;

FETCH NEXT FROM AccountCursor INTO @AccountId

WHILE @@FETCH_STATUS = 0  
BEGIN  

		--call queue cursor
		DECLARE CallQueueCursor CURSOR FOR select CallQueueId, Category from TblCallQueue where IsActive=1 and IsHealthPlan=1;
		DECLARE @CallQueueId BIGINT;
		DECLARE @CallQueueCategory varchar(20);
		OPEN CallQueueCursor;

		FETCH NEXT FROM CallQueueCursor INTO @CallQueueId,@CallQueueCategory

		WHILE @@FETCH_STATUS = 0  
		BEGIN  

				--suppression cursor
				DECLARE SuppressionCursor CURSOR FOR select LookupId,Alias from TblLookup where LookupTypeId = (select LookupTypeId from TblLookupType where Alias='SuppressionType') and IsActive=1
				DECLARE @SuppressionTypeId BIGINT;
				DECLARE @SuppressionType varchar(50);
				OPEN SuppressionCursor;

				FETCH NEXT FROM SuppressionCursor INTO @SuppressionTypeId,@SuppressionType

				WHILE @@FETCH_STATUS = 0  
				BEGIN  

					IF(@CallQueueCategory = 'MailRound')
					BEGIN

						IF(@SuppressionType = 'LeftVoiceMail')
						BEGIN
						   INSERT INTO TblAccountCallQueueSetting (AccountID, CallQueueID,SuppressionTypeID,NoOfDays, DateCreated, IsActive)
						   VALUES(@AccountId, @CallQueueId,@SuppressionTypeId,@MailRoundLeftVoiceMailDefault,GETDATE(), 1)
					    END
						ELSE IF(@SuppressionType = 'Others')
						BEGIN
							INSERT INTO TblAccountCallQueueSetting (AccountID, CallQueueID,SuppressionTypeID,NoOfDays, DateCreated, IsActive)
						    VALUES(@AccountId, @CallQueueId,@SuppressionTypeId,@MailRoundAllCallDefault,GETDATE(), 1)
						END
						ELSE
						BEGIN
							INSERT INTO TblAccountCallQueueSetting (AccountID, CallQueueID,SuppressionTypeID,NoOfDays, DateCreated, IsActive)
						    VALUES(@AccountId, @CallQueueId,@SuppressionTypeId,@RefusedCustomerDefault,GETDATE(), 1)
						END
				    END


					ELSE IF(@CallQueueCategory = 'FillEventsHealthPlan')
					BEGIN

						IF(@SuppressionType = 'LeftVoiceMail' OR @SuppressionType = 'Others')
						BEGIN
						   INSERT INTO TblAccountCallQueueSetting (AccountID, CallQueueID,SuppressionTypeID,NoOfDays, DateCreated, IsActive)
						   VALUES(@AccountId, @CallQueueId,@SuppressionTypeId,@FillEventAllCallDefault,GETDATE(), 1)
					    END
						ELSE
						BEGIN
							INSERT INTO TblAccountCallQueueSetting (AccountID, CallQueueID,SuppressionTypeID,NoOfDays, DateCreated, IsActive)
						    VALUES(@AccountId, @CallQueueId,@SuppressionTypeId,@FillEventRefusedCustomerDefault,GETDATE(), 1)
						END
				    END

					ELSE
					BEGIN

						IF(@SuppressionType = 'LeftVoiceMail' OR @SuppressionType = 'Others')
						BEGIN
						   INSERT INTO TblAccountCallQueueSetting (AccountID, CallQueueID,SuppressionTypeID,NoOfDays, DateCreated, IsActive)
						   VALUES(@AccountId, @CallQueueId,@SuppressionTypeId,@DefaultValueForAll,GETDATE(), 1)
					    END
						ELSE
						BEGIN
							INSERT INTO TblAccountCallQueueSetting (AccountID, CallQueueID,SuppressionTypeID,NoOfDays, DateCreated, IsActive)
						    VALUES(@AccountId, @CallQueueId,@SuppressionTypeId,@RefusedCustomerDefault,GETDATE(), 1)
						END
				    END


				FETCH NEXT FROM SuppressionCursor INTO @SuppressionTypeId,@SuppressionType
				END;
				CLOSE SuppressionCursor;
				DEALLOCATE SuppressionCursor;
				--end suppression cursor

		FETCH NEXT FROM CallQueueCursor INTO @CallQueueId,@CallQueueCategory
		END;
		CLOSE CallQueueCursor;
		DEALLOCATE CallQueueCursor;
		--end call queue cursor



       FETCH NEXT FROM AccountCursor INTO  @AccountId
END;
CLOSE AccountCursor;
DEALLOCATE AccountCursor;

GO
