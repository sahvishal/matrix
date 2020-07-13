USE [$(dbName)]
GO


INSERT INTO  TblExitInterviewQuestion ([Id], [Question], [TypeId], [Gender], [ParentId], [ControlValues], [ControlValueDelimiter], [Index])
VALUES (5, 'Does this member have any urgent or critical findings?', 322, 44, NULL, 'True,False', ',', 2)

Update TblExitInterviewQuestion Set [Index] = 3, Question='Has the CMR process been documented and completed in CHAT' where Id = 2

Update TblExitInterviewQuestion Set [Index] = 4  where Id = 3

Update TblExitInterviewQuestion Set [Index] = 5 where Id = 4


GO