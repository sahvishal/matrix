USE [$(dbname)]
GO

INSERT INTO TblUnit ([Name],[Alias])
SELECT DISTINCT ActiveIngredUnit,ActiveIngredUnit FROM TblNdc WHERE LEN(ActiveIngredUnit) > 0 AND LEN(ActiveIngredUnit) < 500 and ActiveIngredUnit!='/; /; /'

GO