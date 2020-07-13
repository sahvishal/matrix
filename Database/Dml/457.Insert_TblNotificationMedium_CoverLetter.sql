
 USE [$(dbname)]
 GO

 INSERT INTO TblNotificationMedium (NotificationMedium, [Description], DateCreated, DateModified)
 VALUES ('CoverLetter', 'CoverLetter', GETDATE(), GETDATE())

 Declare @NotificationMediumId int 

 SET @NotificationMediumId= (SELECT NotificationMediumID FROM TblNotificationMedium WHERE NotificationMedium='CoverLetter')

 UPDATE TblNotificationType SET NotificationMediumId=@NotificationMediumId WHERE NotificationTypeNameAlias='CoverLetterTemplate'


