
CREATE TABLE Artists (
	ArtistId INT PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL,
	Nationality nvarchar(50) NOT NULL
)

CREATE TABLE Albums (
	AlbumId INT PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL,
	YearOfRelease INT NOT NULL,
	ArtistId INT FOREIGN KEY REFERENCES Artists(ArtistId) NOT NULL
)

CREATE TABLE Songs (
	SongId INT PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL,
	DurationInSeconds INT NOT NULL
)

CREATE TABLE Albums_Songs (
	AlbumId INT FOREIGN KEY REFERENCES Albums(AlbumId),
	SongId INT FOREIGN KEY REFERENCES Songs(SongId)
)

INSERT INTO Artists(Name, Nationality)
VALUES ('Milky Chance','German'),
	   ('Arctic Monkeys','English'),
	   (N'Dragojeviæ Oliver','Croatian') 

INSERT INTO Albums(Name, YearOfRelease, ArtistId)
VALUES ('Sadnecessary',2013,1),
	   ('Blossom',2017,1),
	   ('Favourite Worst Nightmare',2007,2),
	   ('AM',2013,2),
	   ('Vjeruj u ljubav',1979,3),
	   ('Trag u beskraju',2002,3)

INSERT INTO Songs (Name, DurationInSeconds)
VALUES --Sadnecessary
	   ('Stunner', 290),
	   ('Flashed Junk Mind', 264),
	   ('Becoming', 146),
	   ('Running', 270),
	   ('Feathery', 198),
	   ('Indigo', 88),
	   ('Sadnecessary', 300),
	   ('Down by the river', 243),
	   ('Sweet Sun', 276),
	   ('Fairytale', 258),
	   ('Stolen Dance', 315),
	   ('Loveland', 218),
	   --Blossom
	   ('Blossom', 252),
	   ('Ego', 232),
	   ('Firebird', 221),
	   ('Doing Good', 250),
	   ('Cold Blue Rain', 297),
	   ('Bad Things', 252),
	   ('Cocoon', 255),
	   ('Losing You', 272),
	   ('Peripeteia', 223),
	   ('Alive', 250),
	   ('Piano Song', 198),
	   ('Heartless', 402),
	   --Favourite Worst Nightmare
	   ('Brianstorm', 170),
	   ('Teddy Picker', 163),
	   ('D is for Dangerous', 136),
	   ('Balaclava', 169),
	   ('Flourescent Adolescent', 177),
	   ('Only Ones Who Know', 182),
	   ('Do Me a Favour', 207),
	   ('If You Were There, Beware', 274),
	   ('Old Yellow Bricks', 191),
	   ('505', 253),
	   --AM
	   ('Do I Wanna Know', 272),
	   ('R U Mine', 200),
	   ('One for the Road', 206),
	   ('Arabella', 207),
	   ('Snap Out of It', 192),
	   ('Knee Socks', 257),
	   --Vjeruj u ljubav
	   ('Vjeruj u ljubav', 233),
	   ('Vagabundo', 189),
	   ('Ostavljam te samu', 309),
	   ('Ljubav je tvoja kao vino', 255),
	   (N'Kljuè života', 230),
	   --Trag u beskraju
	   ('Trag u beskraju', 276),
	   (N'Teško te zaboravljam', 250),
	   ('Ti si meni sve', 259),
	   (N'Prièa se', 247),
	   ('Zvir', 309)

BEGIN TRANSACTION
INSERT INTO Albums_Songs (AlbumId, SongId)
VALUES (1, 1),
	   (1, 2),
	   (1, 3),
	   (1, 4),
	   (1, 5),
	   (1, 6),
	   (1, 7),
	   (1, 8),
	   (1, 9),
	   (1, 10),
	   (1, 11),
	   (1, 12),
	   (2, 13),
	   (2, 14),
	   (2, 15),
	   (2, 16),
	   (2, 17),
	   (2, 18),
	   (2, 19),
	   (2, 20),
	   (2, 21),
	   (2, 22),
	   (2, 23),
	   (2, 24),
	   (2, 4),
	   (2, 5),
	   (2, 11),
	   (3, 25),
	   (3, 26),
	   (3, 27),
	   (3, 28),
	   (3, 29),
	   (3, 30),
	   (3, 31),
	   (3, 32),
	   (3, 33),
	   (3, 34),
	   (4, 35),
	   (4, 36),
	   (4, 37),
	   (4, 38),
	   (4, 39),
	   (4, 40),
	   (5, 41),
	   (5, 42),
	   (5, 43),
	   (5, 44),
	   (5, 45),
	   (6, 46),
	   (6, 47),
	   (6, 48),
	   (6, 49),
	   (6, 50),
	   (6, 43)

COMMIT