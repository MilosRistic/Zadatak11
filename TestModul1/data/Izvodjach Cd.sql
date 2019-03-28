Use ZaTestiranje

CREATE TABLE Izvodjac
(
id int primary key IDENTITY(1,1),
imePrezime nvarchar(50) UNIQUE,
pol nvarchar(50),

);

CREATE TABLE Cd
(
id int primary key IDENTITY(1,1),
nazivAlbuma nvarchar(50),
drzava nvarchar(50),
imeIzdavackeKuce nvarchar(50),
cena float,
godinaIzdavanja int,
izvodjacUmetnik nvarchar(50),
FOREIGN KEY (izvodjacUmetnik) REFERENCES izvodjac(imePrezime)
);

