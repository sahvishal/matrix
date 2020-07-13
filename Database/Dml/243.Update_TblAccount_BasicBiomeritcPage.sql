USE [$(dbName)]
Go

update TblAccount set ShowBasicBiometricPage=1 where IsHealthPlan=1
