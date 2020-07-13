USE [$(dbName)]
GO
CREATE TABLE TblEventProductType  
(
[Id] [bigint] IDENTITY(1,1) NOT NULL,
EventID BIGINT NOT NULL,
ProductTypeId BIGINT  NOT NULL, 
StartDate DATETIME NOT NULL,
EndDate DATETIME  NULL,
DateCreated DATETIME NOT NULL,
IsActive BIT NOT NULL CONSTRAINT DF_TblEventProductType_IsActive DEFAULT 1,
CONSTRAINT PK_TblEventProductType PRIMARY KEY ([Id]),

CONSTRAINT FK_TblEventProductType_TblEvents_EventID FOREIGN KEY (EventID) REFERENCES [TblEvents](EventID),
)



