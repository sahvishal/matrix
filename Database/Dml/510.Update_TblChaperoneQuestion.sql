USE [$(dbname)]
GO

DELETE FROM TblChaperoneQuestion WHERE Id IN (13,14)

INSERT into TblChaperoneQuestion (Id, Question, TypeId, ParentId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (14, 'Other Reason', 323, 8, 184, '', '', 14)

UPDATE TblChaperoneQuestion SET Id = 13, [Index] = 13 where Id = 15