 USE [$(dbname)]
 GO

 --script to add following sub reasons under Healthfair Reason for change and cancel appointment
 --Site Change, Low Volume, Event Cancelled, Date Change, Template Change, Good News Pack

 --change appointment sub reason 
 -- Healthfair Reason
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (27,232,'SiteChange','Site Change','Site Change',5,GETDATE(),1,1),
	   (28,232,'LowVolume','Low Volume','Low Volume',6,GETDATE(),1,1),
	   (29,232,'EventCancelled','Event Cancelled','Event Cancelled',7,GETDATE(),1,1),
	   (30,232,'DateChange','Date Change','Date Change',8,GETDATE(),1,1),
	   (31,232,'TemplateChange','Template Change','Template Change',9,GETDATE(),1,1),
	   (32,232,'GoodNews','Good News','Good News',10,GETDATE(),1,1),
	   (33,232,'Pack','Pack','Pack',10,GETDATE(),1,1)

GO

--Cancle appointment sub reason
--Healthfair Reason
INSERT INTO [TblRescheduleCancelDisposition] (Id,LookupId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (34,237,'SiteChange','Site Change','Site Change',5,GETDATE(),1,1),
	   (35,237,'LowVolume','Low Volume','Low Volume',6,GETDATE(),1,1),
	   (36,237,'EventCancelled','Event Cancelled','Event Cancelled',7,GETDATE(),1,1),
	   (37,237,'DateChange','Date Change','Date Change',8,GETDATE(),1,1),
	   (38,237,'TemplateChange','Template Change','Template Change',9,GETDATE(),1,1),
	   (39,237,'GoodNews','Good News','Good News',10,GETDATE(),1,1),
	   (40,237,'Pack','Pack','Pack',10,GETDATE(),1,1)

GO