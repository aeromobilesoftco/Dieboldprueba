CREATE TABLE dbo.estado
	(
	idestado INT IDENTITY NOT NULL,
	estado   VARCHAR (50) NULL,
	PRIMARY KEY (idestado)
	)

CREATE TABLE dbo.Equipo
	(
	idequipo INT IDENTITY NOT NULL,
	serial   VARCHAR (100) NULL,
	marca    VARCHAR (100) NULL,
	PRIMARY KEY (idequipo)
	)
	
CREATE TABLE lugar
(
	idlugar INT NOT NULL IDENTITY
	, nombrelugar VARCHAR(100)
	, PRIMARY KEY (idlugar)
)

CREATE TABLE usuario
(
	idusuario INT NOT NULL IDENTITY
	, Tipdoc VARCHAR(2)
	, numdoc VARCHAR(50)
	, nombre VARCHAR(200)
	, direccion VARCHAR(100)
	, telefono VARCHAR(10)
	, PRIMARY KEY (idusuario)
)

CREATE TABLE historiaequipo
(
	idhistoria INT NOT NULL IDENTITY 
	, idequipo INT 
	, idusuario INT 
	, idlugar INT
	, idestado INT 
	, fecentrada DATETIME 
	, fecsalida DATETIME 
	, PRIMARY KEY (idhistoria) 
	, FOREIGN KEY (idequipo) REFERENCES Equipo
	, FOREIGN KEY (idusuario) REFERENCES usuario 
	, FOREIGN KEY (idlugar) REFERENCES lugar 
	, FOREIGN KEY (idestado) REFERENCES estado  
)

            INSERT INTO dbo.estado (estado)
VALUES ('Configuracion')
GO

INSERT INTO dbo.estado (estado)
VALUES ('Transporte')
GO

INSERT INTO dbo.estado (estado)
VALUES ('Disponible')
GO

INSERT INTO dbo.estado (estado)
VALUES ('Mantenimiento')
GO

INSERT INTO dbo.estado (estado)
VALUES ('Dañado')
GO

INSERT INTO dbo.estado (estado)
VALUES ('Garantia')
GO

INSERT INTO dbo.estado (estado)
VALUES ('En uso')
GO
