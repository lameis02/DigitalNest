CREATE TABLE [dbo].[Vogelsammlung] (
    [Id]      INT        NOT NULL,
    [Vogel]   NCHAR (10) NULL,
    [Art]     NCHAR (10) NULL,
    [Datum]   NCHAR (10) NULL,
    [Ort]     NCHAR (10) NULL,
    [Bild]    IMAGE      NULL,
    [Favorit] CHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

