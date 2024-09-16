CREATE TABLE Sedes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(150) NOT NULL,
    Rooms VARCHAR (150),
    Capacity INT, 
    NumberAccomodation INT,
    Description VARCHAR (300),
    Cottage VARCHAR (150),
	FullName VARCHAR(150),
	Type VARCHAR (50) NOT NULL,
	Ubication VARCHAR(150) NOT NULL
);
ALTER TABLE Sedes
ALTER COLUMN Capacity INT NULL;

ALTER TABLE Sedes
ALTER COLUMN NumberAccomodation INT NULL;
INSERT INTO Sedes (Name, Rooms, Capacity, NumberAccomodation, Description, Cottage, FullName, Type, Ubication)
VALUES 
    ('Sede Recreativa el placer Fusagasugá', 
     '7 Habitaciones',     
     '34',       -- Capacidad como texto
     '4',       -- Número de alojamiento como texto
     'Esta sede recreativa se encuentra ubicada en la vereda, el placer del municipio de Fusagasugá, a unos 10 minutos del casco urbano', 
     'Cuatro unidades de la N°5 a la N°8', 
     'Sede Recreativa el placer',       
     'Sede Recreativa',  
     'Fusagasugá'
    ),
    ('Tablones Palmira', 
     '6 Habitaciones',     
     '24',       -- Capacidad como texto
     '4',       -- Número de alojamiento como texto
     'Disfruta en familia de nuestra renovada sede para el bienestar Tablones Palmira ubicada en el Municipio de Palmira, Corregimiento de Tablones. Kilómetro 13 # 3 -23, a 15 kilómetros sobre la vía al municipio de Ginebra y con un clima promedio de 23°. Con un total de 4 alojamientos (2 para 8 personas, 1 para 4 personas) dotados con baño y cocina, además de un Kiosko con televisor y zona de juegos bajo techo.', 
     'posee cabaña y zona BBQ', 
     'Sede Recreativa Tablones Palmira',       
     'Sede',  
     'Antioquia'
    ),
    ('Gonzalo Moronte', 
     '9 Habitaciones',     
     '30',       -- Capacidad como texto
     '6',       -- Número de alojamiento como texto
     'Ubicados en el edificio Reina 1 de la carrera 3 número 7 - 85 centro urbano y turístico, El Rodadero y a tres cuadras de la playa', 
     'Bloque de cabañas A y B', 
     'Sedes Recreativa Gonzalo Moronte',       
     'Sede',  
     'Chinchiná Caldas'
    );

ALTER TABLE Sedes
ALTER COLUMN Description VARCHAR(1000);  --  Ajustamos el tamaño según sea necesario




SELECT * FROM Sedes;
DELETE FROM Sedes
WHERE Id = 2[FONDOXYZ];

SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Sedes';





CREATE TABLE Users (
Id INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR (150) NOT NULL,
Email VARCHAR (150) NOT NULL,
Password NVARCHAR (100) NOT NULL,
DocumentNumber VARCHAR (50) NOT NULL,
DateBirth DATE NOT NULL,
DateRegistered DATE NOT NULL
);

CREATE TABLE Apartamentos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    NumberRooms INT NOT NULL, 
    CapacityMaximum NVARCHAR(50) NOT NULL,
    SedeId INT,
    FOREIGN KEY (SedeId) REFERENCES Sedes(Id)
);


CREATE TABLE Tarifas (
Id INT IDENTITY(1,1) PRIMARY KEY,
ApartamentoId INT,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL, 
PriceNight FLOAT
);




