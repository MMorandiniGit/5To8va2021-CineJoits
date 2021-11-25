DROP DATABASE IF EXISTS cine;
CREATE DATABASE cine;

USE cine;

CREATE TABLE Cliente (
	idCliente smallint NOT NULL AUTO_INCREMENT,
	nombre varchar(45) NOT NULL,
	apellido varchar(45) NOT NULL,
	mail varchar(60) NOT NULL,
	pass char(64) NOT NULL,
	CONSTRAINT PK_CLIENTE PRIMARY KEY (idCliente ASC)
);

CREATE TABLE Entrada (
	numeroentrada smallint NOT NULL,
	idProyeccion smallint NOT NULL,
	idCliente smallint NOT NULL,
	valor decimal(6,2) NOT NULL,
	CONSTRAINT PK_ENTRADA PRIMARY KEY (numeroentrada ASC,idProyeccion ASC)
);

CREATE TABLE Pelicula (
	idPelicula smallint NOT NULL AUTO_INCREMENT,
	genero varchar(45) NOT NULL,
	fecha date NOT NULL,
	nombre varchar(45) NOT NULL,
	CONSTRAINT PK_PELICULA PRIMARY KEY (idPelicula ASC)
);

CREATE TABLE Proyeccion (
	idProyeccion smallint NOT NULL AUTO_INCREMENT,
	idSala tinyint NOT NULL,
	idPelicula smallint NOT NULL,
	fechahora datetime NOT NULL,
	CONSTRAINT PK_PROYECCION PRIMARY KEY (idProyeccion ASC)
);

CREATE TABLE sala (
	idsala tinyint NOT NULL AUTO_INCREMENT,
	piso tinyint NOT NULL,
	capacidad smallint UNSIGNED,
	CONSTRAINT PK_CLIENTE PRIMARY KEY (idsala ASC)
);

ALTER TABLE Cliente ADD CONSTRAINT UQ_Cliente_mail UNIQUE (mail ASC);  
ALTER TABLE Pelicula ADD CONSTRAINT UQ_Pelicula_nombre UNIQUE (nombre ASC); 


ALTER TABLE Entrada ADD CONSTRAINT FK_ENTRADA_CLIENTE FOREIGN KEY (idCliente) REFERENCES cliente (idCliente) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE Entrada ADD CONSTRAINT FK_ENTRADA_PROYECCION FOREIGN KEY (idProyeccion) REFERENCES proyeccion (idProyeccion) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE Proyeccion ADD CONSTRAINT FK_PROYECCION_PELICULA FOREIGN KEY (idPelicula) REFERENCES pelicula (idPelicula) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE Proyeccion ADD CONSTRAINT FK_PROYECCION_SALA FOREIGN KEY (idSala) REFERENCES sala (idsala) ON DELETE No Action ON UPDATE No Action;