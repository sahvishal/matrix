USE [$(dbname)]
GO

INSERT INTO TblEventCustomerPrimaryCarePhysician  (EventCustomerId,PrimaryCarePhysicianId)
SELECT ec.EventCustomerID, cpcc.PrimaryCarePhysicianID FROM TblEventCustomers ec
JOIN TblCustomerPrimaryCarePhysician cpcc ON ec.CustomerID = cpcc.CustomerID
WHERE cpcc.IsActive = 1
AND ec.EventCustomerID NOT IN 
(
	SELECT EventCustomerID FROM TblEventCustomerPrimaryCarePhysician
)
GO