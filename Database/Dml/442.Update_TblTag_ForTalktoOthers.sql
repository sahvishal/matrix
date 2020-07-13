USE [$(dbname)]
GO

UPDATE TblTag SET ForLeftMessageWithOthers = ForTalkedToOthers

UPDATE TblTag SET ForTalkedToOthers = 0


IF NOT Exists((SELECT * FROM TblTag WHERE Name='Incorrect Phone Number' AND Alias='IncorrectPhoneNumber_TalkedToOthers'))
BEGIN
  INSERT INTO TblTag (Source,[Name],Alias,IsActive,IsSystemDefined,IsHealthPlanTag,ForLeftMessageWithOthers,ForAppointmentConfirmation,ForTalkedToOthers) 
             VALUES('107','Incorrect Phone Number','IncorrectPhoneNumber_TalkedToOthers',1,0,1,0,0,1)
END
ELSE 
BEGIN 
  UPDATE TblTag SET IsActive=1,ForLeftMessageWithOthers = 0,IsSystemDefined = 0,IsHealthPlanTag = 1,ForAppointmentConfirmation = 0,ForTalkedToOthers =1 WHERE [Name]='Incorrect Phone Number' AND Alias='IncorrectPhoneNumber_TalkedToOthers'
END
