insert into Materia values('Matemática 1')
insert into Materia values('Programación de computadoras')
insert into Materia values('Diseño Editorial')

insert into Idioma values('Español')
insert into Idioma values ('Inglés')

insert into TipoUsuario values('Estudiante')
insert into TipoUsuario values('Profesor')
insert into TipoUsuario values('Administrador')

insert into Carrera values('Licenciatura en Sistemas')
insert into Carrera values('Diseño y Comunicación Visual')

insert into Universidad values('Universidad Nacional de Lanus')
insert into Universidad values('Universidad de Buenos Aires')

insert into Usuario values('Juan', 'Gomez', '39000111', 'estudiante1@email.com', '1234', 1)
insert into Usuario values('Jose', 'Perez', '39000112', 'estudiante2@email.com', '1234', 1)
insert into Usuario values('Julio', 'Perro', '39000113', 'profesor1@email.com', '1234', 2)
insert into Usuario values('Rick', 'Sanchez', '39000114', 'profesor2@email.com', '1234', 2)
insert into Usuario values('Bruno', 'Diaz', '39000115', 'profesor3@email.com', '1234', 2)
insert into Usuario values('Morgan', 'Freeman', '39000116', 'administrador@email.com', '1234', 3)

insert into CarreraMateria values(1, 1)
insert into CarreraMateria values(1, 2)
insert into CarreraMateria values(2, 3)
insert into CarreraMateria values(2, 1)

insert into UniversidadCarrera values(1, 1)
insert into UniversidadCarrera values(2, 2)

insert into UsuarioMateria values(1, 1)
insert into UsuarioMateria values(1, 2)
insert into UsuarioMateria values(2, 1)
insert into UsuarioMateria values(2, 3)

insert into UsuarioCarreraUniversidad values(1, 1, 1)
insert into UsuarioCarreraUniversidad values(2, 2, 2)
insert into UsuarioCarreraUniversidad values(3, 1, 1)
insert into UsuarioCarreraUniversidad values(4, 1, 1)
insert into UsuarioCarreraUniversidad values(5, 2, 2)