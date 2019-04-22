CREATE TABLE TypeOfCars
(
             Id   INT IDENTITY,
             Name NVARCHAR(50) NOT NULL,
             CONSTRAINT PK_TypeOfCars PRIMARY KEY(Id)
);

CREATE TABLE CarManufacturer
(
             Id        INT IDENTITY,
             Name      NVARCHAR(50) UNIQUE NOT NULL,
             TypeOfCarsId INT NOT NULL,
             CONSTRAINT PK_CarManufacturer PRIMARY KEY(Id),
             CONSTRAINT FK_CarManufacturer_TypeOfCars FOREIGN KEY(TypeOfCarsId) REFERENCES TypeOfCars(Id)
);

CREATE TABLE Cars
(
             Id     INT IDENTITY,
             Name   NVARCHAR(50) NOT NULL,
             Model  NVARCHAR(50)  NOT NULL,
             Transmission  NVARCHAR(50)  NOT NULL,
             GazType  NVARCHAR(50)  NOT NULL,
			 EngineLitres FLOAT NOT NULL,
             CarManufacturerId INT NOT NULL,
             CONSTRAINT PK_Cars PRIMARY KEY(Id),
             CONSTRAINT FK_Cars_CarManufacturer FOREIGN KEY(CarManufacturerId) REFERENCES CarManufacturer(Id)
);

