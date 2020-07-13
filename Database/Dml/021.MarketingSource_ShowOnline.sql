
USE [$(dbName)]
Go

Declare @MarketingSource varchar(250)

set @MarketingSource ='Television'

If Exists(select * from TblMarketingSource where Label=@MarketingSource)
begin
	update TblMarketingSource
	Set ShowOnline=1, IsActive=1
	where Label =@MarketingSource
end
else
begin
	INSERT [dbo].[TblMarketingSource] 
		([Label],[Notes],[DateCreated],[DateModified],[IsActive],[ShowOnline])
	VALUES
		(@MarketingSource,NULL,GETDATE(),GETDATE(),1,1)
End

set @MarketingSource ='Radio'
If Exists(select * from TblMarketingSource where Label=@MarketingSource)
begin
	update TblMarketingSource
	Set ShowOnline=1, IsActive=1
	where Label =@MarketingSource
end
else
begin
	INSERT [dbo].[TblMarketingSource] 
		([Label],[Notes],[DateCreated],[DateModified],[IsActive],[ShowOnline])
	VALUES
		(@MarketingSource,NULL,GETDATE(),GETDATE(),1,1)
End

set @MarketingSource ='Newspaper'
If Exists(select * from TblMarketingSource where Label=@MarketingSource)
begin
	update TblMarketingSource
	Set ShowOnline=1, IsActive=1
	where Label =@MarketingSource
end
else
begin
	INSERT [dbo].[TblMarketingSource] 
		([Label],[Notes],[DateCreated],[DateModified],[IsActive],[ShowOnline])
	VALUES
		(@MarketingSource,NULL,GETDATE(),GETDATE(),1,1)
End

set @MarketingSource ='Word of Mouth'
If Exists(select * from TblMarketingSource where Label=@MarketingSource)
begin
	update TblMarketingSource
	Set ShowOnline=1, IsActive=1
	where Label =@MarketingSource
end
else
begin
	INSERT [dbo].[TblMarketingSource] 
		([Label],[Notes],[DateCreated],[DateModified],[IsActive],[ShowOnline])
	VALUES
		(@MarketingSource,NULL,GETDATE(),GETDATE(),1,1)
End

set @MarketingSource ='Internet'
If Exists(select * from TblMarketingSource where Label=@MarketingSource)
begin
	update TblMarketingSource
	Set ShowOnline=1, IsActive=1
	where Label =@MarketingSource
end
else
begin
	INSERT [dbo].[TblMarketingSource] 
		([Label],[Notes],[DateCreated],[DateModified],[IsActive],[ShowOnline])
	VALUES
		(@MarketingSource,NULL,GETDATE(),GETDATE(),1,1)
End

set @MarketingSource ='Mailer'
If Exists(select * from TblMarketingSource where Label=@MarketingSource)
begin
	update TblMarketingSource
	Set ShowOnline=1, IsActive=1
	where Label =@MarketingSource
end
else
begin
	INSERT [dbo].[TblMarketingSource] 
		([Label],[Notes],[DateCreated],[DateModified],[IsActive],[ShowOnline])
	VALUES
		(@MarketingSource,NULL,GETDATE(),GETDATE(),1,1)
End

set @MarketingSource ='Flyer'
If Exists(select * from TblMarketingSource where Label=@MarketingSource)
begin
	update TblMarketingSource
	Set ShowOnline=1, IsActive=1
	where Label =@MarketingSource
end
else
begin
	INSERT [dbo].[TblMarketingSource] 
		([Label],[Notes],[DateCreated],[DateModified],[IsActive],[ShowOnline])
	VALUES
		(@MarketingSource,NULL,GETDATE(),GETDATE(),1,1)
End