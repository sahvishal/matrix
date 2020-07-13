USE [$(dbName)]
GO

update TblExitInterviewQuestion set Question = 'Have all preapproved or clinically indicated tests were done for the member?' where id = 1
update TblExitInterviewQuestion set Question = 'Has the CMR process been documented and completed in CHAT?' where id = 2
update TblExitInterviewQuestion set Question = 'Ensure in CHAT, all clinically indicated tests were ordered in HIP' where id = 3

