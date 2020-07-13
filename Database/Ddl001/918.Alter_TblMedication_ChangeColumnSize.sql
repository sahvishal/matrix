USE [$(dbname)]
GO

Alter Table TblMedication Alter Column NdcProductCode varchar(50)
Alter Table TblMedication Alter Column ProprietaryName varchar(100)

Alter Table tblNdc Alter Column ProductName varchar(100)
Alter Table tblNdc Alter Column NdcCode varchar(50)
Alter Table tblNdc Alter Column ActiveIngredUnit varchar(50)
Alter Table tblNdc Alter Column ActiveNumeratorStrength varchar(50)