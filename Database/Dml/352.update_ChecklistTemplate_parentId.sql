USE [$(dbname)]
GO


update TblChecklistGroupQuestion set ParentId = null where QuestionId in (22,23,24,25)