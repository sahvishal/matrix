USE [$(dbName)]

GO

insert into TblAdditionalFields (Id, Name,Alias,DateCreated,CreatedBy) values (1,'Additional Field 1','AdditionalField1',getdate(),1)
insert into TblAdditionalFields (Id,Name,Alias,DateCreated,CreatedBy) values (2,'Additional Field 2','AdditionalField2',getdate(),1)
insert into TblAdditionalFields (Id,Name,Alias,DateCreated,CreatedBy) values (3,'Additional Field 3','AdditionalField3',getdate(),1)
insert into TblAdditionalFields (Id,Name,Alias,DateCreated,CreatedBy) values (4,'Additional Field 4','AdditionalField4',getdate(),1)