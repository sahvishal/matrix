USE [$(dbName)]
Go

DECLARE @lookUpTypeId BIGINT

INSERT INTO TblLookupType (Alias,DisplayName, [Description],DateCreated,DateModified ) 
VALUES ('EventCustomNotificationStatus', 'Event Custom Notification Status', 'Event Custom Notification Status', GETDATE(), GETDATE())

SET @lookUpTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
VALUES (338, @lookUpTypeId, 'Unserviced', 'Unserviced', 'Unserviced', 1, GETDATE(), null, 1, null, 1 ),
	   (339, @lookUpTypeId, 'Serviced', 'Serviced', 'Serviced', 2, GETDATE(), null, 1, null, 1 ),
	   (340, @lookUpTypeId, 'Failed', 'Failed', 'Failed', 3, GETDATE(), null, 1, null, 1 )
GO
