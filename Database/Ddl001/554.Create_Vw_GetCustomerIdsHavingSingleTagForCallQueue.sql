use [$(dbName)]
go

IF OBJECT_ID ('Vw_GetCustomerIdsHavingSingleTagForCallQueue', 'view') IS NOT NULL  
	DROP VIEW Vw_GetCustomerIdsHavingSingleTagForCallQueue 
GO 

CREATE VIEW Vw_GetCustomerIdsHavingSingleTagForCallQueue
As

SELECT CustomerId FROM TblCustomerTag ct WITH(NOLOCK) WHERE ct.IsActive = 1 GROUP BY ct.CustomerId HAVING COUNT(ct.CustomerId) = 1