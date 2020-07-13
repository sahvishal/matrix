USE [$(dbName)]
Go

Update TblDirectMailType set Name =	'The Golden Letter', Alias = 'TheGoldenLetter' where Id=1
Update TblDirectMailType set Name =	'General Letter', Alias = 'GeneralLetter' where Id=2
Update TblDirectMailType set Name =	'Trying To Reach You Letter', Alias = 'TryingToReachYouLetter' where Id=3
Update TblDirectMailType set Name =	'Event Specific Letter', Alias = 'EventSpecificLetter' where Id=4