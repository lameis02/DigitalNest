CREATE DATABASE Vogeldatenbank;
GO
USE Vogeldatenbank;
GO
CREATE TABLE Vogelsammlung (
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    Vogel NCHAR(10) NULL, 
    Art NCHAR(10) NULL, 
    Datum NCHAR(10) NULL, 
    Ort NCHAR(10) NULL, 
    Bild IMAGE NULL, 
    Favorit NCHAR(10) NULL
);
GO
