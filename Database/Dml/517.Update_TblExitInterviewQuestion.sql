
USE [$(dbname)]
GO

UPDATE TblExitInterviewQuestion SET Question = 'Were all pre-approved and client eligible screenings completed and/or dispositioned in CHAT?' where id = 1
UPDATE TblExitInterviewQuestion SET Question = 'Ensure all performed client eligible screenings in CHAT were ordered in HIP' where id = 3