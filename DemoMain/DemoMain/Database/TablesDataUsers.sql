--CREATE TABLE TypeOfCars
--(
--			 Id   INT IDENTITY,
--			 Name NVARCHAR(50) NOT NULL,
--			 CONSTRAINT PK_TypeOfCars PRIMARY KEY(Id)
--);

--CREATE TABLE CarManufacturer
--(
--			 Id        INT IDENTITY,
--			 Name      NVARCHAR(50) UNIQUE NOT NULL,
--			 TypeOfCarsId INT NOT NULL,
--			 CONSTRAINT PK_CarManufacturer PRIMARY KEY(Id),
--			 CONSTRAINT FK_CarManufacturer_TypeOfCars FOREIGN KEY(TypeOfCarsId) REFERENCES TypeOfCars(Id)
--);

CREATE TABLE Users
(
			 Id     INT IDENTITY,
			 Name   NVARCHAR(50) NOT NULL,
			 SurName   NVARCHAR(50) NOT NULL,
			 Nickname  NVARCHAR(50)  NOT NULL,
			 EMAIL  NVARCHAR(50)  NOT NULL,
			 PASSWORD  NVARCHAR(50)  NOT NULL,
			 CONSTRAINT PK_Users PRIMARY KEY(Id),
);

INSERT INTO Users
VALUES
(
	   'Andriy',
	   'Zagreichuk',
	   'admin',
	   'zagrei4uk1@gmail.com',
	   'admin'
	   
);
--CREATE TABLE Villains
--(
--             Id             INT IDENTITY,
--             Name           NVARCHAR(50) NOT NULL,
--             EvilnessFactor NVARCHAR(25) NOT NULL,
--             CONSTRAINT PK_Villains PRIMARY KEY(Id)
--);

--CREATE TABLE CarsVillains
--(
--             CarsId  INT,
--             VillainId INT,
--             CONSTRAINT PK_CarsVillains PRIMARY KEY(CarsId, VillainId),
--             CONSTRAINT FK_CarsVillains_Cars FOREIGN KEY(CarsId) REFERENCES Cars(Id),
--             CONSTRAINT FK_CarsVillains_Villains FOREIGN KEY(VillainId) REFERENCES Villains(Id)
--);

--INSERT INTO TypeOfCars
--VALUES
--(
--	   'Hatchback'
--),
--(
--	   'Sportcar'
--),
--(
--	   'Supercar'
--),
--(
--	   'Hypercar'
--),
--(
--	   'Electric'
--);

--INSERT INTO CarManufacturer
--VALUES
--(
--	   'Audi',
--	   1
--),
--(
--	   'BMW',
--	   2
--),
--(
--	   'Mercedes',
--	   3
--),
--(
--	   'Ford',
--	   4
--),
--(
--	   'VW',
--	   5
--);



--INSERT INTO Villains
--VALUES
--(
--       'Bad Guy',
--       'Bad'
--),
--(
--       'Evil Guy',
--       'Evil'
--),
--(
--       'Good Dude',
--       'Good'
--),
--(
--       'Good Friend',
--       'Good'
--),
--(
--       'Super Evil Guy',
--       'Super evil'
--);

--INSERT INTO MinionsVillains
--VALUES
--(
--       1,
--       3
--),
--(
--       2,
--       4
--),
--(
--       3,
--       5
--),
--(
--       4,
--       1
--),
--(
--       5,
--       1
--),
--(
--       3,
--       1
--),
--(
--       2,
--       1
--),
--(
--       5,
--       3
--);