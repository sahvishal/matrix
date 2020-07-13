USE [$(dbName)]
Go

Insert Into TblTestNotPerformedReason (Id,Name,Alias,Createdby,CreatedOn) values(1,'Patient Refused','PatientRefused',1,GETDATE())
Insert Into TblTestNotPerformedReason (Id,Name,Alias,Createdby,CreatedOn) values(2,'Contraindication','Contraindication',1,GETDATE())
Insert Into TblTestNotPerformedReason (Id,Name,Alias,Createdby,CreatedOn) values(3,'Patient Left Without Test Being Performed','PatientLeftWithoutTestBeingPerformed',1,GETDATE())
Insert Into TblTestNotPerformedReason (Id,Name,Alias,Createdby,CreatedOn) values(4,'Test Previously Performed This Year','TestPreviouslyPerformedThisYear',1,GETDATE())