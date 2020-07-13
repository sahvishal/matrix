
USE [$(dbName)]
Go

begin try

Begin Tran
------------------------------------------
delete from [TblStandardFindingtestreading]
delete from [TblStandardFinding]
delete from [TblTestReading]
delete from [TblReading]
delete from [TblIncidentalFindingReadingGroupItem]
delete from [TblIncidentalFindingIncidentalFindingReadingGroup]
delete from [TblIncidentalFindingReadingGroup]
delete from [TblIncidentalFindings]

---------------------------------------------------


delete from [TblTest]
-----------------------------------------


INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price,DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(1,'Stroke','Two carotid arteries (one on each side of the neck) supply most of the blood to the brain. The carotid arteries can easily be felt on each side of the neck immediately below the angle of the jaw. There are two smaller arteries, the vertebral arteries, which run through the spine and supply blood to the back part of the brain (the brainstem and cerebellum). The carotid arteries supply the much larger front part of the brain, where thinking, speech, personality and sensory and motor functions reside.',1,'Nov 12 2007 12:00:00:000AM','May  9 2008  6:06:48:173PM',59.00,59.00,59.00,59.00,'Stroke and Carotid Artery',1,1)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price,DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(2,'Peripheral Artery Disease','Peripheral vascular disease refers to diseases of blood vessels outside the heart and brain. It''s often a narrowing of vessels that carry blood',1,'Nov 12 2007 12:00:00:000AM','Apr 21 2008  2:25:18:793AM',45.00,45.00,45.00,45.00,'Peripheral Artery Disease',1,2)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price,DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(3,'Arterial Stiffness Index','The arterial stiffness index is the relationship between the arterial blood pressure and the dimensions of the carotid artery. The researchers measured blood pressure and used ultrasound to measure the diameter of the artery.',1,'Nov 12 2007 12:00:00:000AM','Apr 21 2008  2:24:12:463AM',39.00,39.00,39.00,39.00,'Arterial Stiffness Index',1,3)

INSERT INTO [TblTest] ([TestID], [Name], [Description], [IsActive], [DateCreated], [DateModified], Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice, [Alias], [Version],RelativeOrder) 
VALUES (4, 'Echocardiogram', 'Echocardiogram', 1, GETDATE(), GETDATE(),	25, 25,	25, 25, 'Echocardiogram',	2,4) 

INSERT INTO [TblTest] ([TestID], [Name], [Description], [IsActive], [DateCreated], [DateModified], Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice, [Alias], [Version],RelativeOrder) 
VALUES (5, 'Thyroid', 'Thyroid', 1, GETDATE(), GETDATE(),	45, 45,	45, 45, 'Thyroid',	2,5) 

INSERT INTO [TblTest] ([TestID], [Name], [Description], [IsActive], [DateCreated], [DateModified], Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice, [Alias], [Version],RelativeOrder) 
VALUES (6, 'Atrial Fibrillation Heart Rhythm', 'Atrial Fibrillation Heart Rhythm', 1, GETDATE(), GETDATE(),	25, 25,	25, 25, 'Atrial Fibrillation Heart Rhythm',	2,6) 

INSERT INTO [TblTest] ([TestID], [Name], [Description], [IsActive], [DateCreated], [DateModified], Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice, [Alias], [Version],RelativeOrder) 
VALUES (7, 'Pulmonary Function', 'Pulmonary Function ', 1, GETDATE(), GETDATE(),	25, 25,	25, 25, 'Pulmonary Function ',	2,7) 

INSERT INTO [TblTest] ([TestID], [Name], [Description], [IsActive], [DateCreated], [DateModified], Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice, [Alias], [Version],RelativeOrder) 
VALUES (8, 'IMT', 'This safe, painless, FDA approved test for adults ages 40-75', 1, GETDATE(), GETDATE(),	59, 59,	59, 59, 'IMT',	2,8) 
	
INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(9,'Osteoporosis','Osteoporosis is a disease of bone leading to an increased risk of fracture. In osteoporosis the bone mineral density (BMD) is reduced, bone microarchitecture is disrupted, and the amount and variety of non-collagenous proteins in bone is altered',1,'Nov 23 2007  3:06:39:293PM','Apr 21 2008  2:24:54:497AM',19.00,19.00,19.00,19.00,'Osteoporosis',1,9)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(10,'Abdominal Aortic Aneurysm','An aneurysm is when a blood vessel becomes abnormally large or balloons outward. The abdominal aorta is a large blood vessel that supplies blood to your abdomen, the pelvis, and legs.',1,'Nov 23 2007  3:06:59:507PM','Apr 21 2008  2:23:36:277AM',49.00,49.00,49.00,49.00,'Abdominal Aortic Aneurysm',1,10)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(11,'ECG/EKG','Test ECG/EKG',1,'Nov  5 2009  3:02:05:013AM','Nov  5 2009  3:02:05:013AM',45.00,45.00,45.00,45.00,'EKG',2,11)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(12,'Lipid Panel','Test Lipid Panel',1,'Nov  5 2009  3:02:05:030AM','Nov  5 2009  3:02:05:030AM',59.00,59.00,59.00,59.00,'Lipid Panel',2,12)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(13,'Liver Function','Test Liver Function',1,'Nov  5 2009  3:02:05:030AM','Nov  5 2009  3:02:05:030AM',24.00,24.00,24.00,24.00,'Liver Function',2,13)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(14,'Framingham Risk','Test Framingham Risk',1,'Nov 30 2009  2:45:00:930AM','Nov 30 2009  2:45:00:930AM',29.00,29.00,29.00,29.00,'Framingham Risk',2,14)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(15,'Colorectal','Test Colorectal',1,'May  3 2010  4:24:19:043AM','Jul 21 2010  1:47:57:337AM',30.00,30.00,30.00,30.00,'Colorectal',2,15)

INSERT INTO [TblTest] ([TestID],[Name],[Description],[IsActive],[DateCreated],[DateModified],Price, DefaultPackagePrice,RefundPrice,DefaultPackageRefundPrice,[Alias],[Version],RelativeOrder)
VALUES(16,'Breast Cancer','Test Breast Cancer',1,'May  3 2010  4:24:19:043AM','Jul 21 2010  1:47:57:337AM',179.00,179.00,179.00,179.00,'Breast Cancer',2,16)

INSERT [dbo].[TblTest] ([TestID],[Name],[Description]
			,[IsActive],[DateCreated],[DateModified],[Alias],[Version],[RelativeOrder],[CPTCode],[IsRecordable],[IsTestReviewableByPhysician],[ShowInCustomerPDF],[Price]
			,[DefaultPackagePrice],[RefundPrice],[DefaultPackageRefundPrice],[MinAge],[MaxAge],[DiagnosisCode],[ShowInAlaCarte],[ScreeningTime], HAFTemplateId, IsSelectedByDefaultForEvent)
VALUES(28,'Testosterone','Testosterone'
,1,getdate(),getdate(),'Testosterone',1,27,NULL,1,0,0,25.00,25.00,25.00,25.00,NULL,NULL,NULL,1,NULL, NULL, 0)

INSERT [dbo].[TblTest] ([TestID],[Name],[Description]
			,[IsActive],[DateCreated],[DateModified],[Alias],[Version],[RelativeOrder],[CPTCode],[IsRecordable],[IsTestReviewableByPhysician],[ShowInCustomerPDF],[Price]
			,[DefaultPackagePrice],[RefundPrice],[DefaultPackageRefundPrice],[MinAge],[MaxAge],[DiagnosisCode],[ShowInAlaCarte],[ScreeningTime], HAFTemplateId, IsSelectedByDefaultForEvent)
VALUES(29,'Screening Mammogram Digital','Screening Mammogram Digital'
,1,getdate(),getdate(),'Mammogram',1,28,'G0202',0,0,0,140.00,140.00,140.00,140.00,NULL,NULL,NULL,0,NULL, NULL, 0)


INSERT [dbo].[TblTest] ([TestID],[Name],[Description]
			,[IsActive],[DateCreated],[DateModified],[Alias],[Version],[RelativeOrder],[CPTCode],[IsRecordable],[IsTestReviewableByPhysician],[ShowInCustomerPDF],[Price]
			,[DefaultPackagePrice],[RefundPrice],[DefaultPackageRefundPrice],[MinAge],[MaxAge],[DiagnosisCode],[ShowInAlaCarte],[ScreeningTime], HAFTemplateId, IsSelectedByDefaultForEvent)
VALUES(30,'Computer-Aided Detection','Computer-Aided Detection'
,1,getdate(),getdate(),'CAD',1,29,'77052',0,0,0,10.00,10.00,10.00,10.00,NULL,NULL,NULL,0,NULL, NULL, 0)

INSERT [dbo].[TblTest] ([TestID],[Name],[Description]
			,[IsActive],[DateCreated],[DateModified],[Alias],[Version],[RelativeOrder],[CPTCode],[IsRecordable],[IsTestReviewableByPhysician],[ShowInCustomerPDF],[Price]
			,[DefaultPackagePrice],[RefundPrice],[DefaultPackageRefundPrice],[MinAge],[MaxAge],[DiagnosisCode],[ShowInAlaCarte],[ScreeningTime], HAFTemplateId, IsSelectedByDefaultForEvent)
VALUES(31,'Flu Shot','Flu Shot'
,1,getdate(),getdate(),'FluShot',1,29,'90658',0,0,0,25.00,25.00,25.00,25.00,NULL,NULL,NULL,0,NULL, NULL, 0)


INSERT [dbo].[TblTest] ([TestID],[Name],[Description]
			,[IsActive],[DateCreated],[DateModified],[Alias],[Version],[RelativeOrder],[CPTCode],[IsRecordable],[IsTestReviewableByPhysician],[ShowInCustomerPDF],[Price]
			,[DefaultPackagePrice],[RefundPrice],[DefaultPackageRefundPrice],[MinAge],[MaxAge],[DiagnosisCode],[ShowInAlaCarte],[ScreeningTime], HAFTemplateId, IsSelectedByDefaultForEvent)
VALUES(32,'Annual Wellness Visit','Annual Wellness Visit'
,1,getdate(),getdate(),'AWV',1,30,'',0,0,0,25.00,25.00,25.00,25.00,NULL,NULL,NULL,0,NULL, NULL, 0)


INSERT [dbo].[TblTest] ([TestID],[Name],[Description]
			,[IsActive],[DateCreated],[DateModified],[Alias],[Version],[RelativeOrder],[CPTCode],[IsRecordable],[IsTestReviewableByPhysician],[ShowInCustomerPDF],[Price]
			,[DefaultPackagePrice],[RefundPrice],[DefaultPackageRefundPrice],[MinAge],[MaxAge],[DiagnosisCode],[ShowInAlaCarte],[ScreeningTime], HAFTemplateId, IsSelectedByDefaultForEvent)
VALUES(33,'5-Lead Electrocardiogram (EKG)','5-Lead Electrocardiogram (EKG)'
,1,getdate(),getdate(),'5-Lead EKG',1,31,'',0,0,0,25.00,25.00,25.00,25.00,NULL,NULL,NULL,0,NULL, NULL, 0)
------------------------------------------------------

Update TblTest Set IsRecordable = 0 where IsActive = 0

Commit Tran

end try
begin catch
	IF @@TRANCOUNT > 0
		ROLLBACK TRAN
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
		 @ErrSeverity = ERROR_SEVERITY()	
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
end catch