
USE [$(dbName)]
Go


Alter Table TblEventCustomerBasicBiometric Add IsBloodPressureElevated bit constraint DF_IsBloodPressureElevated_BasicBiometric default(0)