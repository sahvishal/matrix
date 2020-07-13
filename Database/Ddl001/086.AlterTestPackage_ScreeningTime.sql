USE [$(dbName)]
Go

Alter Table TblPackage Add ScreeningTime int null 

Alter Table TblTest Add ScreeningTime int null 

Alter Table TblEventPackageDetails Add ScreeningTime int null 

Alter Table TblEventTest Add ScreeningTime int null 