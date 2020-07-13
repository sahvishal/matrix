USE [$(dbname)]
GO

-- Change appointment reason
INSERT INTO TblLookup (LookupId, LookupTypeId,Alias,DisplayName,Description,RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (369,37,'EventToFar','Event to far','Event to far',13,GETDATE(),1,1),
	   (370,37,'MobilityIssue','Mobility Issue','Mobility Issue',14,GETDATE(),1,1),
	   (371,37,'SICKILL','SICK/ILL','SICK/ILL',15,GETDATE(),1,1),
	   (372,37,'TransportationIssue','Transportation Issue','Transportation Issue',16,GETDATE(),1,1),
	   (373,37,'UNAWAREOFAPPOINTMENT','UNAWARE OF APPOINTMENT','UNAWARE OF APPOINTMENT',17,GETDATE(),1,1)

GO

-- Cancel appointment reason
INSERT INTO TblLookup (LookupId, LookupTypeId,Alias,DisplayName,Description,RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (374,49,'Deceased','Deceased','Deceased',14,GETDATE(),1,1),
	   (375,49,'EventToFar','Event to far','Event to far',15,GETDATE(),1,1),
	   (376,49,'Healthplan','Healthplan','Healthplan',16,GETDATE(),1,1),
	   (377,49,'MobilityIssue','Mobility Issue','Mobility Issue',17,GETDATE(),1,1),
	   (378,49,'Other','Other','Other',18,GETDATE(),1,1),
	   (379,49,'SICKILL','SICK/ILL','SICK/ILL',19,GETDATE(),1,1),
	   (380,49,'TransportationIssue','Transportation Issue','Transportation Issue',20,GETDATE(),1,1),
	   (381,49,'UNAWAREOFAPPOINTMENT','UNAWARE OF APPOINTMENT','UNAWARE OF APPOINTMENT',21,GETDATE(),1,1)
	   --,(382,49,'PREFERSPCP','PREFERS PCP','PREFERS PCP',1212,GETDATE(),1,1)

GO
