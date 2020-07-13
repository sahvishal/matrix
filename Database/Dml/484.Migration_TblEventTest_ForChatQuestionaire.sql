 USE [$(dbname)]
 GO
 
 --run this script only when there is any future events and ChatStartDate is present on some test for CHAT Questionnaire

 DECLARE @ChatQuestionnaire BIGINT = 421 
 
 UPDATE ET SET ET.ResultEntryTypeId = @ChatQuestionnaire FROM TblTest T
 INNER JOIN TblEventTest ET ON T.TestID = ET.TestID
 INNER JOIN TblEvents E ON ET.EventID = E.EventID
 INNER JOIN TblEventAccount EA ON E.EventID = EA.EventID
 INNER JOIN TblAccount A ON EA.AccountID = A.AccountID
 WHERE A.IsHealthPlan = 1 AND T.ChatStartDate IS NOT NULL AND E.EventDate > T.ChatStartDate
 Go