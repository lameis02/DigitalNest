CREATE DATABASE Vogeldatenbank;
GO
USE Vogeldatenbank;
GO
CREATE TABLE Vogelsammlung (
    Id INT NOT NULL Identity(1,1) PRIMARY KEY, 
    Art NCHAR(25) NULL, 
    Datum NCHAR(11) NULL, 
    Ort NCHAR(20) NULL, 
    Bild IMAGE NULL, 
    Favorit Bit NULL,
);
GO
