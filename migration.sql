CREATE TABLE [Carrera] (
    [idCarrera] int NOT NULL IDENTITY,
    [carrera] varchar(45) NOT NULL,
    CONSTRAINT [PK_Carrera] PRIMARY KEY ([idCarrera])
);
GO

CREATE TABLE [Idioma] (
    [idIdioma] int NOT NULL IDENTITY,
    [idioma] varchar(45) NOT NULL,
    CONSTRAINT [PK_Idioma] PRIMARY KEY ([idIdioma])
);
GO

CREATE TABLE [Materia] (
    [idMateria] int NOT NULL IDENTITY,
    [Materia] varchar(45) NOT NULL,
    CONSTRAINT [PK_Materia] PRIMARY KEY ([idMateria])
);
GO

CREATE TABLE [TipoUsuario] (
    [idTipoUsuario] int NOT NULL IDENTITY,
    [nombreTipoUsuario] varchar(45) NOT NULL,
    CONSTRAINT [PK_TipoUsuario] PRIMARY KEY ([idTipoUsuario])
);
GO

CREATE TABLE [Universidad] (
    [idUniversidad] int NOT NULL IDENTITY,
    [nombreUniversidad] varchar(45) NOT NULL,
    CONSTRAINT [PK_Universidad] PRIMARY KEY ([idUniversidad])
);
GO

CREATE TABLE [CarreraMateria] (
    [idCarrera] int NOT NULL,
    [idMateria] int NOT NULL,
    CONSTRAINT [PK_CarreraMateria] PRIMARY KEY ([idCarrera], [idMateria]),
    CONSTRAINT [FK_CarreraMateria_Carrera] FOREIGN KEY ([idCarrera]) REFERENCES [Carrera] ([idCarrera]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CarreraMateria_Materia] FOREIGN KEY ([idMateria]) REFERENCES [Materia] ([idMateria]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Usuario] (
    [idUsuario] int NOT NULL IDENTITY,
    [nombre] varchar(45) NOT NULL,
    [apellido] varchar(45) NOT NULL,
    [dni] varchar(8) NOT NULL,
    [email] varchar(45) NOT NULL,
    [clave] varchar(45) NOT NULL,
    [idTipoUsuario] int NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([idUsuario]),
    CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY ([idTipoUsuario]) REFERENCES [TipoUsuario] ([idTipoUsuario]) ON DELETE NO ACTION
);
GO

CREATE TABLE [UniversidadCarrera] (
    [idUniversidad] int NOT NULL,
    [idCarrera] int NOT NULL,
    CONSTRAINT [PK_UniversidadCarrera] PRIMARY KEY ([idUniversidad], [idCarrera]),
    CONSTRAINT [FK_UniversidadCarrera_Carrera] FOREIGN KEY ([idCarrera]) REFERENCES [Carrera] ([idCarrera]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UniversidadCarrera_Universidad] FOREIGN KEY ([idUniversidad]) REFERENCES [Universidad] ([idUniversidad]) ON DELETE NO ACTION
);
GO

CREATE TABLE [MaterialEstudio] (
    [IdMaterial] int NOT NULL IDENTITY,
    [titulo] varchar(45) NOT NULL,
    [descripcion] varchar(45) NOT NULL,
    [prologo] varchar(45) NOT NULL,
    [autor] varchar(45) NOT NULL,
    [archivo] varbinary(max) NOT NULL,
    [miniatura] varbinary(max) NOT NULL,
    [idIdioma] int NOT NULL,
    [idUsuario] int NOT NULL,
    [idMateria] int NOT NULL,
    [idUniversidad] int NOT NULL,
    CONSTRAINT [PK_MaterialEstudio] PRIMARY KEY ([IdMaterial]),
    CONSTRAINT [FK_MaterialEstudio_Idioma] FOREIGN KEY ([idIdioma]) REFERENCES [Idioma] ([idIdioma]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MaterialEstudio_Materia] FOREIGN KEY ([idMateria]) REFERENCES [Materia] ([idMateria]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MaterialEstudio_Universidad] FOREIGN KEY ([idUniversidad]) REFERENCES [Universidad] ([idUniversidad]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MaterialEstudio_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [Usuario] ([idUsuario]) ON DELETE NO ACTION
);
GO

CREATE TABLE [UsuarioCarreraUniversidad] (
    [idUsuario] int NOT NULL,
    [idCarrera] int NOT NULL,
    [idUniversidad] int NOT NULL,
    CONSTRAINT [PK_UsuarioCarreraUniversidad] PRIMARY KEY ([idUsuario], [idCarrera], [idUniversidad]),
    CONSTRAINT [FK_UsuarioCarreraUniversidad_Carrera] FOREIGN KEY ([idCarrera]) REFERENCES [Carrera] ([idCarrera]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UsuarioCarreraUniversidad_Universidad] FOREIGN KEY ([idUniversidad]) REFERENCES [Universidad] ([idUniversidad]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UsuarioCarreraUniversidad_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [Usuario] ([idUsuario]) ON DELETE NO ACTION
);
GO

CREATE TABLE [UsuarioMateria] (
    [idUsuario] int NOT NULL,
    [idMateria] int NOT NULL,
    CONSTRAINT [PK_UsuarioMateria] PRIMARY KEY ([idUsuario], [idMateria]),
    CONSTRAINT [FK_UsuarioMateria_Materia] FOREIGN KEY ([idMateria]) REFERENCES [Materia] ([idMateria]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UsuarioMateria_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [Usuario] ([idUsuario]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Reseña] (
    [idReseña] int NOT NULL IDENTITY,
    [comentario] varchar(45) NOT NULL,
    [puntuacion] int NOT NULL,
    [idMaterial] int NOT NULL,
    [idUsuario] int NOT NULL,
    CONSTRAINT [PK_Reseña] PRIMARY KEY ([idReseña]),
    CONSTRAINT [FK_Reseña_MaterialEstudio] FOREIGN KEY ([idMaterial]) REFERENCES [MaterialEstudio] ([IdMaterial]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Reseña_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [Usuario] ([idUsuario]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_CarreraMateria_idMateria] ON [CarreraMateria] ([idMateria]);
GO

CREATE INDEX [IX_MaterialEstudio_idIdioma] ON [MaterialEstudio] ([idIdioma]);
GO

CREATE INDEX [IX_MaterialEstudio_idMateria] ON [MaterialEstudio] ([idMateria]);
GO

CREATE INDEX [IX_MaterialEstudio_idUniversidad] ON [MaterialEstudio] ([idUniversidad]);
GO

CREATE INDEX [IX_MaterialEstudio_idUsuario] ON [MaterialEstudio] ([idUsuario]);
GO

CREATE INDEX [IX_Reseña_idMaterial] ON [Reseña] ([idMaterial]);
GO

CREATE INDEX [IX_Reseña_idUsuario] ON [Reseña] ([idUsuario]);
GO

CREATE INDEX [IX_UniversidadCarrera_idCarrera] ON [UniversidadCarrera] ([idCarrera]);
GO

CREATE INDEX [IX_Usuario_idTipoUsuario] ON [Usuario] ([idTipoUsuario]);
GO

CREATE INDEX [IX_UsuarioCarreraUniversidad_idCarrera] ON [UsuarioCarreraUniversidad] ([idCarrera]);
GO

CREATE INDEX [IX_UsuarioCarreraUniversidad_idUniversidad] ON [UsuarioCarreraUniversidad] ([idUniversidad]);
GO

CREATE INDEX [IX_UsuarioMateria_idMateria] ON [UsuarioMateria] ([idMateria]);
GO