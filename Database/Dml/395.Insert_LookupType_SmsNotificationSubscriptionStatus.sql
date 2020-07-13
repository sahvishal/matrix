USE [$(dbname)]
GO

	DECLARE @LookupTypeId BIGINT

	IF Not Exists ( select * from TblLookupType where Alias = 'SmsNotificationSubscriptionStatus')
	BEGIN

		INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated, DateModified)
			VALUES ('SmsNotificationSubscriptionStatus','Sms Notification Subscription Status','Sms Notification Subscription Status',GETDATE(),GETDATE())
	END

	SELECT @LookupTypeId = LookupTypeID FROM TblLookupType WHERE Alias = 'SmsNotificationSubscriptionStatus' 

	IF Not Exists ( select LookupId from TblLookup where Alias = 'Unsubscribe' and LookupTypeId = @LookupTypeId)
	BEGIN

		INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
				VALUES (351,@LookupTypeId,'Unsubscribe','Unsubscribe',NULL,1,GETDATE(),1,1)
	END

	IF Not Exists ( select LookupId from TblLookup where Alias = 'Subscribe' and LookupTypeId = @LookupTypeId)
	BEGIN

		INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
				VALUES (352,@LookupTypeId,'Subscribe','Subscribe',NULL,2,GETDATE(),1,1)
	END
