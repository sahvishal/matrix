USE [$(dbname)]
GO

CREATE TABLE TblRelationship
(
	RelationshipId BIGINT NOT NULL,
	Code VARCHAR(50) NOT NULL,
	[Description] VARCHAR(255) NOT NULL,
	Alias VARCHAR(255) NOT NULL,
	CONSTRAINT PK_TblRelationship PRIMARY KEY (RelationshipId)
)
GO