USE [$(dbName)]
Go

DECLARE @lookUpTypeId BIGINT

INSERT INTO TblLookupType (Alias,DisplayName, [Description],DateCreated,DateModified ) 
VALUES ('PayPeriodCriteriaType', 'Pay Period Criteria Type', 'Pay Period Criteria Type', GETDATE(), GETDATE())

SET @lookUpTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
VALUES (334, @lookUpTypeId, 'LessThanEqualTo', 'Less Than Equal To', 'Less Than Equal To', 1, GETDATE(), null, 1, null, 1 ),
	   (335, @lookUpTypeId, 'Between', 'Between', 'Between', 2, GETDATE(), null, 1, null, 1 ),
	   (336, @lookUpTypeId, 'GreaterThanEqualTo', 'Greater Than Equal To', 'Greater Than Equal To', 3, GETDATE(), null, 1, null, 1 )
GO
