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

create table Universidad(
idUniversidad int not null primary key identity,
nombreUniversidad varchar(45) not null)
go

create table Carrera(
idCarrera int not null primary key identity,
carrera varchar(45) not null,
idUniversidad int not null
CONSTRAINT [FK_Carrera_Universidad] FOREIGN KEY ([idUniversidad]) REFERENCES [Universidad]([idUniversidad]))
go


CREATE TABLE Usuario (
idUsuario int not null primary key identity,
nombre varchar(45) not null,
email varchar(45) not null,
clave varchar(45) not null,
tipoUsuario int not null, 
dni varchar(8) not null,
idCarrera int not null,
 CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY ([tipoUsuario]) REFERENCES [TipoUsuario]([idTipoUsuario]),
  CONSTRAINT [FK_Usuario_Carrera] FOREIGN KEY ([idCarrera]) REFERENCES [Carrera]([idCarrera])
 )
 go

Create table MaterialEstudio (
	idMateriaEstudio int not null primary key identity,
	titulo varchar(45) not null,
	descripcion varchar(45) not null,
	idioma int not null,
	materia int not null,
	usuario int not null,
	autor varchar(45) not null,
	archivo varbinary(MAX) not null,
	miniatura varbinary(MAX) not null,
	prologo varchar(max) not null,
 CONSTRAINT [FK_Idioma_MateriaEstudio] FOREIGN KEY ([idioma]) REFERENCES [Idioma]([idIdioma]),
 CONSTRAINT [FK_Materia_MateriaEstudio] FOREIGN KEY ([materia]) REFERENCES [Materia]([idMateria]),
 CONSTRAINT [FK_Material_Usuario] FOREIGN KEY ([usuario]) REFERENCES [Usuario]([idUsuario])
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

create table PuntuacionMaterial(
	idPuntuacion int identity not null primary key,
	idUsuario int not null,
	idMaterial int not null,
	puntuacion int not null,
	comentario varchar(200) not null,
	CONSTRAINT [FK_Puntuacion_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [Usuario]([idUsuario]),
	CONSTRAINT [FK_Puntuacion_Material] FOREIGN KEY ([idMaterial]) REFERENCES [MaterialEstudio]([idMateriaEstudio])
)