USE [$(dbName)]
GO

Alter Table TblAccount Add AllowVerifiedMembersOnly bit NOT NULL Constraint DF_TblAccount_AllowVerifiedMembersOnly default 0
GO

Alter Table TblAccount Add FirstName bit NOT NULL Constraint DF_TblAccount_FirstName default 0
GO

Alter Table TblAccount Add MemberId bit NOT NULL Constraint DF_TblAccount_MemberId default 0
GO

Alter Table TblAccount Add Zipcode bit NOT NULL Constraint DF_TblAccount_Zipcode default 0
GO

Alter Table TblAccount Add LastName bit NOT NULL Constraint DF_TblAccount_LastName default 0
GO

Alter Table TblAccount Add DateOfBirth bit NOT NULL Constraint DF_TblAccount_DateOfBirth default 0
GO

Alter Table TblAccount Add Email bit NOT NULL Constraint DF_TblAccount_Email default 0
GO

Alter Table TblAccount Add SendResultReadyMailWithFax bit NOT NULL Constraint DF_TblAccount_SendResultReadyMailWithFax default 0
GO

