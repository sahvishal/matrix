
USE [$(dbName)]
Go

Alter Table TblTempCart Add MarketingSource varchar(500)
Alter Table TblPackage Add DescriptiononUpsellSection varchar(2000)