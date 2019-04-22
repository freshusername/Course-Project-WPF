

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