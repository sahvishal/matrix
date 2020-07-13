USE [$(dbName)]
GO 

	DECLARE @languageId bigint

	SELECT @languageId=Id FROM TblLanguage WHERE Name='english'
	
	IF NOT EXISTS (SELECT 1 FROM TblLanguage WHERE Name='ENGLISH')
	BEGIN
		INSERT INTO TblLanguage 
				(Name,Alias,DateCreated,CreatedByOrgRoleUserId,IsActive)
				VALUES   ('ENGLISH','ENGLISH',GETDATE(),1,1)

		SET @languageId = Scope_Identity()
	END

	UPDATE TblCustomerProfile SET LanguageId=@languageId WHERE PreferredLanguage ='english'
	UPDATE TblCustomerProfile SET LanguageId=@languageId WHERE PreferredLanguage ='Spanish/English'
	UPDATE TblCustomerProfile SET LanguageId=@languageId WHERE PreferredLanguage ='Englis'
	UPDATE TblCustomerProfile SET LanguageId=@languageId WHERE PreferredLanguage ='eng'

	SELECT @languageId=Id FROM TblLanguage WHERE Name='Spanish'
	
	IF NOT EXISTS (SELECT 1 FROM TblLanguage WHERE Name='SPANISH')
	BEGIN
		INSERT INTO TblLanguage 
				(Name,Alias,DateCreated,CreatedByOrgRoleUserId,IsActive)
				VALUES   ('SPANISH','SPANISH',GETDATE(),1,1)

		SET @languageId = Scope_Identity()
	END
	
	UPDATE TblCustomerProfile SET LanguageId=@languageId WHERE PreferredLanguage ='Spanish'
	
	IF NOT EXISTS (SELECT 1 FROM TblLanguage WHERE Name='KOREAN')
	BEGIN
		INSERT INTO TblLanguage 
				(Name,Alias,DateCreated,CreatedByOrgRoleUserId,IsActive)
				VALUES   ('KOREAN','KOREAN',GETDATE(),1,1)

		SET @languageId = Scope_Identity()
	END

UPDATE TblCustomerProfile SET LanguageId=@languageId WHERE PreferredLanguage ='Korean'
