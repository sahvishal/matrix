USE [$(dbname)]
GO
--change appointment sub reason 

 -- Healthfair Reason
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (1,232,'FieldBusIssue','Field/Bus Issue','Field/Bus Issue',1,GETDATE(),1,1),
	   (2,232,'REDFLAG','RED FLAG','RED FLAG',2,GETDATE(),1,1),
	   (3,232,'YELLOWFLAG','YELLOW FLAG','YELLOW FLAG',3,GETDATE(),1,1),
	   (4,232,'UnitRequest','Unit request','Unit request',4,GETDATE(),1,1)

GO
--Mobility Issue
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (5,370,'TemporaryMobilityIssue','Temporary Mobility Issue','Temporary Mobility Issue',1,GETDATE(),1,1)

GO

--Schedule Conflict
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (6,206,'OutOfTown','Out of Town','Out of Town',1,GETDATE(),1,1),
	   (7,206,'DeathInFamilyFuneral','Death in family/Funeral','Death in family/Funeral',2,GETDATE(),1,1),
	   (8,206,'Emergency','Emergency','Emergency',3,GETDATE(),1,1),
	   (9,206,'Work','Work','Work',4,GETDATE(),1,1)

GO

--Transportation Issue
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (10,372,'PTDoesNotHaveTransportationPlanDoesNotOffer','PT does not have transportation, plan does not offer','PT does not have transportation, plan does not offer',1,GETDATE(),1,1),
	   (11,372,'HealthfairDidNotRequestConfirmTransportation','Healthfair did not request/confirm transportation','Healthfair did not request/confirm transportation',2,GETDATE(),1,1)

GO

--Cancle appointment sub reason

--Healthplan
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (12,376,'NotEligible','Not Eligible','Not Eligible',1,GETDATE(),1,1),
	   (13,376,'ChangeInsurance','Change insurance','Change insurance',2,GETDATE(),1,1),
	   (14,376,'RequestByHealthplan','Request by Healthplan','Request by Healthplan',3,GETDATE(),1,1)

GO

--Healthfair Reason
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (15,237,'FieldBusIssue','Field/Bus Issue','Field/Bus Issue',1,GETDATE(),1,1),
	   (16,237,'REDFLAG','RED FLAG','RED FLAG',2,GETDATE(),1,1),
	   (17,237,'YELLOWFLAG','YELLOW FLAG','YELLOW FLAG',3,GETDATE(),1,1),
	   (18,237,'UnitRequest','Unit Request','Unit Request',4,GETDATE(),1,1)

GO

--Mobility Issue
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (19,377,'TemporaryMobilityIssue','Temporary Mobility Issue','Temporary Mobility Issue',1,GETDATE(),1,1),
	   (20,377,'PermanantMobilityIssue','Permanant Mobility Issue','Permanant Mobility Issue',2,GETDATE(),1,1)

GO

--Transportation Issue
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (21,380,'PTDoesNotHaveTransportationPlanDoesNotOffer','PT does not have transportation, plan does not offer','PT does not have transportation, plan does not offer',1,GETDATE(),1,1),
	   (22,380,'HealthfairDidNotRequestConfirmTransportation','Healthfair did not request/confirm transportation','Healthfair did not request/confirm transportation',2,GETDATE(),1,1)

GO

--Schedule Conflict
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (23,210,'OutOfTown','Out of Town','Out of Town',1,GETDATE(),1,1),
	   (24,210,'DeathInFamilyFuneral','Death in family/Funeral','Death in family/Funeral',2,GETDATE(),1,1),
	   (25,210,'Emergency','Emergency','Emergency',3,GETDATE(),1,1),
	   (26,210,'Work','Work','Work',4,GETDATE(),1,1)
GO
