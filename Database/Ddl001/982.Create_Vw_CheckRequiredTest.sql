USE [$(dbName)]
GO

CREATE VIEW Vw_CheckRequiredTest
AS
    SELECT E.EventID, rt.CustomerId
	FROM TblEvents e
	JOIN TblRequiredTest RT on rt.ForYear = YEAR(e.EventDate) AND rt.IsActive = 1 
	LEFT JOIN TblEventTest et on et.EventID = e.EventID AND et.TestID = rt.TestId
	WHERE et.TestId is NULL and e.EventDate > GETDATE() and e.EventStatus = 1


