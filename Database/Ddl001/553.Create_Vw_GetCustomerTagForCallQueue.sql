use [$(dbName)]
go

IF OBJECT_ID ('Vw_GetCustomerTagForCallQueue', 'view') IS NOT NULL  
	DROP VIEW Vw_GetCustomerTagForCallQueue 
GO 

Create View Vw_GetCustomerTagForCallQueue
As
SELECT  CustomerTagId, 
		CustomerId, 
		Tag, 
		DateCreated, 
		DateModified, 
		CreatedByOrgRoleUserId, 
		ModifiedByOrgRoleUserId, 
		IsActive
		
		FROM TblCustomerTag With(NOLOCK) WHERE IsActive = 1



