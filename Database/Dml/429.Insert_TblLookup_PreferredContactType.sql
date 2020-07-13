USE [$(dbname)]
GO

DECLARE @lookupTypeId BIGINT

INSERT INTO TblLookupType (Alias, DisplayName,Description, DateCreated, DateModified)
VALUES ('PreferredContactType','Preferred Contact Type','Preferred Contact Type', GETDATE(),NULL)

SELECT @lookupTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES (382,@lookupTypeId ,'Email','Email','Email',1,GETDATE(),1,1),
	   (383,@lookupTypeId ,'Phone','Phone','Phone',2,GETDATE(),1,1)

GO
