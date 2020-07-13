USE [$(dbname)]
GO


If NOT EXISTS (select 1 from TblActivityType Where Alias = 'None')
 Begin
	    INSERT INTO TblActivityType (Name,Alias,CreatedDate,CreatedBy,IsActive)
		VALUES ('None','None',GETDATE(),1,1)	
 End
