
USE [$(dbName)]
GO

--select * from TblToolTip

--For Integra and PHS - Insurance Id

IF Exists(Select * from TblToolTip where Tag='InsuranceIdLabel')
Begin
	Update TblToolTip
	set Content = 'Member Id'
	where Tag='InsuranceIdLabel'	
End
Else
Begin
	Insert Into TblToolTip
		(Tag, Content)
	Values
		('InsuranceIdLabel','Member Id')
end