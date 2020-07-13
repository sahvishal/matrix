USE [$(dbName)]
Go

update TblReading set Label='Right Foot: Sensation Intact',CreatedOn=GETDATE() where ReadingId=425
update TblReading set Label='Right Foot: Sensation not Intact',CreatedOn=GETDATE() where ReadingId=426
update TblReading set Label='Left Foot: Sensation Intact',CreatedOn=GETDATE() where ReadingId=427
update TblReading set Label='Left Foot: Sensation not Intact ',CreatedOn=GETDATE() where ReadingId=428
	
