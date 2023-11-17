CREATE TABLE [dbo].[Vogelsammlung] (
    [Id]    INT        NOT NULL IDENTITY,
    [Vogel] NCHAR (10) NULL,
    [Art]   NCHAR (10) NOT NULL,
    [Datum] NCHAR (10) NOT NULL,
    [Ort]   NCHAR (10) NOT NULL,
    [Bild] IMAGE NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

