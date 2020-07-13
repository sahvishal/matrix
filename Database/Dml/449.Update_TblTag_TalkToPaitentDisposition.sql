USE [$(dbname)]
GO


IF NOT Exists((SELECT * FROM TblTag WHERE Name='Declined Mobile and Transferred to Home' AND Alias='DeclinedMobileAndTransferredToHome'))
BEGIN
  INSERT INTO TblTag (Source, [Name], Alias, IsActive, IsSystemDefined, IsHealthPlanTag, ForAppointmentConfirmation, ForWarmTransfer, CallStatus) 
             VALUES('107', 'Declined Mobile and Transferred to Home', 'DeclinedMobileAndTransferredToHome', 1, 0, 1, 0, 1, 34)
END
ELSE 
BEGIN 
  UPDATE TblTag SET IsActive=1, IsSystemDefined = 0, IsHealthPlanTag = 1, ForAppointmentConfirmation = 0, ForWarmTransfer = 1 WHERE [Name]='Declined Mobile and Transferred to Home' AND Alias='DeclinedMobileAndTransferredToHome'
END

GO

IF NOT Exists((SELECT * FROM TblTag WHERE Name='Declined Mobile and Home Visit' AND Alias='DeclinedMobileAndHomeVisit'))
BEGIN
  INSERT INTO TblTag (Source, [Name], Alias, IsActive, IsSystemDefined, IsHealthPlanTag, ForAppointmentConfirmation, ForWarmTransfer, CallStatus) 
             VALUES('107', 'Declined Mobile and Home Visit', 'DeclinedMobileAndHomeVisit', 1, 0, 1, 0, 1, 34)
END
ELSE 
BEGIN 
  UPDATE TblTag SET IsActive=1, IsSystemDefined = 0, IsHealthPlanTag = 1, ForAppointmentConfirmation = 0, ForWarmTransfer = 1 WHERE [Name]='Declined Mobile and Home Visit' AND Alias='DeclinedMobileAndHomeVisit'
END
