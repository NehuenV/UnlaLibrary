insert into Universidad values('Universidad Nacional de Lanus')
insert into Universidad values('Universidad de Buenos Aires')

insert into Carrera values('Licenciatura en Sistemas')
insert into Carrera values('Ingenieria Civil')

insert into Materia values('Matematica')
insert into Materia values('Programación')
insert into Materia values('Fisica')

insert into Idioma values('Español')
insert into Idioma values ('Inglés')

insert into TipoUsuario values('Estudiante')
insert into TipoUsuario values('Profesor')
insert into TipoUsuario values('Administrador')

insert into Carrera_Materia values(1, 1)
insert into Carrera_Materia values(1, 2)
insert into Carrera_Materia values(2, 3)
insert into Carrera_Materia values(2, 1)

insert into Universidad_Carrera values(1, 1)
insert into Universidad_Carrera values(2, 2)





insert into Usuario values(1111, 'Juan Gomez', 'juangomez@email.com', '1234', 1)
insert into Usuario values(1112, 'Jose Perez', 'joseperez@email.com', '1234', 1)
insert into Usuario values(1113, 'Julio Perro', 'lic1@email.com', '1234', 2)
insert into Usuario values(1114, 'Rick Sanchez', 'lic2@email.com', '1234', 2)
insert into Usuario values(1115, 'Bruno Diaz', 'lic3@email.com', '1234', 2)
insert into Usuario values(1116, 'Pedro Caballo', 'lic4@email.com', '1234', 2)
insert into Usuario values(1117, 'Señor Administrador', 'admin@email.com', 1234, 3)

insert into UsuarioMateria values(1, 1)
insert into UsuarioMateria values(1, 2)
insert into UsuarioMateria values(2, 3)
insert into UsuarioMateria values(2, 1)