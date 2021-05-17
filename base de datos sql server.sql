create table Materia(
idMateria int not null primary key identity,
materia varchar(45) not null)
go

CREATE TABLE Idioma  (
   idIdioma  INT NOT NULL IDENTITY primary key,
   idioma  VARCHAR(45) NOT NULL,
 )
 go

CREATE TABLE TipoUsuario (
idTipoUsuario int primary key not null identity,
nombreTipoUsuario varchar(45) not null)
go

create table Carrera(
idCarrera int not null primary key identity,
carrera varchar(45) not null)
go

create table Universidad(
idUniversidad int not null primary key identity,
nombreUniversidad varchar(45) not null)
go

CREATE TABLE Usuario (
idUsuario int not null primary key identity,
nombre varchar(45) not null,
email varchar(45) not null,
clave varchar(45) not null,
tipoUsuario int not null, 
 CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY ([tipoUsuario]) REFERENCES [TipoUsuario]([idTipoUsuario])
 )
 go

Create table MaterialEstudio (
	idMateriaEstudio int not null primary key identity,
	titulo varchar(45) not null,
	descripcion varchar(45) not null,
	idioma int not null,
	materia int not null,
	autor varchar(45) not null,
	archivo varbinary(MAX) not null,
 CONSTRAINT [FK_Idioma_MateriaEstudio] FOREIGN KEY ([idioma]) REFERENCES [Idioma]([idIdioma]),
 CONSTRAINT [FK_Materia_MateriaEstudio] FOREIGN KEY ([materia]) REFERENCES [Materia]([idMateria])
)
go

create table UsuarioMateria(
idUsuario int not null ,
idMateria int not null ,
 CONSTRAINT [FK_Usuario_Materia] FOREIGN KEY ([idMateria]) REFERENCES [Materia]([idMateria]),
 CONSTRAINT [FK_Materia_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [Usuario]([idUsuario])
)
go

Create table Carrera_Materia
(
idCarrera int not null,
idMateria int not null,
 CONSTRAINT [FK_Carrera_Materia] FOREIGN KEY ([idCarrera]) REFERENCES [Carrera]([idCarrera]),
 CONSTRAINT [FK_Materia_Carrera] FOREIGN KEY ([idMateria]) REFERENCES [Materia]([idMateria])
)
go

Create table Universidad_Carrera
(
idUniversidad int not null,
idCarrera int not null,
 CONSTRAINT [FK_Universidad_Carrera] FOREIGN KEY ([idUniversidad]) REFERENCES [Universidad]([idUniversidad]),
 CONSTRAINT [FK_Carrera_Universidad] FOREIGN KEY ([idCarrera]) REFERENCES [Carrera]([idCarrera])
)
go