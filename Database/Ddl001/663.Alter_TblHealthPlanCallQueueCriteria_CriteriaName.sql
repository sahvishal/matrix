USE [$(dbname)]

GO
 
ALTER TABLE TblHealthPlanCallQueueCriteria
ADD CriteriaName nvarchar(255)

GO