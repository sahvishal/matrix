USE [$(dbName)]
GO

UPDATE TblActivityType SET Alias = 'MailOnly' WHERE Id = 1
UPDATE TblActivityType SET Alias = 'OnlyCall' WHERE Id = 2
UPDATE TblActivityType SET Alias = 'BothMailAndCall' WHERE Id = 3
UPDATE TblActivityType SET Alias = 'DoNotCallDoNotMail' WHERE Id = 4

GO