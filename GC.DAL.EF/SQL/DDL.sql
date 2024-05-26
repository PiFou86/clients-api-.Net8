IF DB_ID('clients') IS NULL
BEGIN
	CREATE DATABASE clients;
END
GO

USE clients;
GO

CREATE TABLE Client (
    ClientId UNIQUEIDENTIFIER PRIMARY KEY,
    Nom VARCHAR(30) NOT NULL,
    Prenom VARCHAR(30) NOT NULL,
    DateNaissance DATE NULL
);
GO

CREATE TABLE Adresse (
    AdresseId UNIQUEIDENTIFIER PRIMARY KEY,
    ClientId UNIQUEIDENTIFIER NOT NULL,
    NumeroCivique INT NOT NULL,
	InformationComplementaire VARCHAR(512) NULL,
    Odonyme VARCHAR(50) NOT NULL,
	TypeVoie VARCHAR(50) NOT NULL,
	CodePostal VARCHAR(10) NOT NULL,
    NomMunicipalite VARCHAR(50) NOT NULL,
	Etat VARCHAR(50) NOT NULL,
	Pays VARCHAR(50) NOT NULL
    CONSTRAINT FK_Adresse_Proprietaire_Adresse FOREIGN KEY (ClientId) REFERENCES Client(ClientId)
);
GO

DECLARE @c1 UNIQUEIDENTIFIER = NEWID();
DECLARE @c2 UNIQUEIDENTIFIER = NEWID();
DECLARE @c3 UNIQUEIDENTIFIER = NEWID();
INSERT INTO Client(ClientId, Nom, Prenom) VALUES (@c1, 'Vière', 'Marie');
INSERT INTO Client(ClientId, Nom, Prenom) VALUES (@c2, 'Éparbal', 'Gille');
INSERT INTO Client(ClientId, Nom, Prenom) VALUES (@c3, 'Terrieur', 'Alex');

INSERT INTO Adresse(AdresseId, ClientId, NumeroCivique, Odonyme, TypeVoie, CodePostal, NomMunicipalite, Etat, Pays) VALUES (NEWID(), @c1, '123', 'Vire-Crêpe', 'rue', 'G1Z 1W2', 'Lévis', 'Québec', 'Canada');
INSERT INTO Adresse(AdresseId, ClientId, NumeroCivique, Odonyme, TypeVoie, CodePostal, NomMunicipalite, Etat, Pays) VALUES (NEWID(), @c1, '123', 'Toundra', 'rue', 'G1Z 1Z2', 'Québec', 'Québec', 'Canada');
INSERT INTO Adresse(AdresseId, ClientId, NumeroCivique, Odonyme, TypeVoie, CodePostal, NomMunicipalite, Etat, Pays) VALUES (NEWID(), @c2, '123', 'Champlain', 'boulvard', 'G1Z 1Q2', 'Montréal', 'Québec', 'Canada');
