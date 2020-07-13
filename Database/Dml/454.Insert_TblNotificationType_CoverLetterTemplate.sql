 USE [$(dbname)]
 GO

INSERT INTO TblNotificationType (NotificationTypeName,NotificationTypeNameAlias,Description,DateCreated,IsActive,NoOfAttempts,IsServiceEnabled,IsQueuingEnabled,NotificationMediumId,AllowTemplateCreation)
 VALUES('Cover Letter Template','CoverLetterTemplate','Cover Letter Template',GEtDATE(),1,1,0,0,1,0)  

 GO