CREATE TABLE [dbo].[Vogelsammlung]
(
	[Id] INT NOT NULL PRIMARY KEY , 
    [Vogel] NCHAR(10) NOT NULL, 
    [Art] NVARCHAR(50) NULL, 
    [Datum] DATETIME NULL, 
    [Ort] VARCHAR(50) NULL
)
