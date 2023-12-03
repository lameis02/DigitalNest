CREATE TABLE [dbo].[Vogelsammlung]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Vogel] NCHAR(10) NULL, 
    [Art] NCHAR(10) NULL, 
    [Datum] NCHAR(10) NULL, 
    [Ort] NCHAR(10) NULL, 
    [Bild] IMAGE NULL, 
    [Favorit] NCHAR(10) NULL
)
