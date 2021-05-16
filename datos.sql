
use unlalibrary

insert into Universidad values('Universidad Nacional de Lanus')
insert into Universidad values('Universidad de Buenos Aires')

insert into Carrera values('Licenciatura en Sistemas')
insert into Carrera values('Ingenieria Civil')

insert into Materia values('Matematica')
insert into Materia values('Programaci�n')
insert into Materia values('Fisica')

insert into Carrera_Materia values(1, 1)
insert into Carrera_Materia values(1, 2)
insert into Carrera_Materia values(2, 3)
insert into Carrera_Materia values(2, 1)

insert into Universidad_Carrera values(1, 1)
insert into Universidad_Carrera values(2, 2)

insert into Idioma values('Espa�ol')
insert into Idioma values ('Ingl�s')

insert into MaterialEstudio values('Fundamentos de programaci�n', 'descripcion 1', 1, 2)
insert into MaterialEstudio values('Fundamentos de programaci�n 2', 'descripcion 2', 1, 2)
insert into MaterialEstudio values('Database Programming', 'description in english', 2, 2)	
insert into MaterialEstudio values('Matematica basica', 'descripcion matematica basica', 1, 1)
insert into MaterialEstudio values('Matematica basica 2', 'descripcion matematica basica 2', 1, 1)
insert into MaterialEstudio values('Fisica b�sica', 'descripcion fisica basica', 1, 3)

insert into TipoUsuario values('Estudiante')
insert into TipoUsuario values('Profesor')
insert into TipoUsuario values('Administrador')

insert into Usuario values('Juan Gomez', 'juangomez@email.com', '1234', 1)
insert into Usuario values('Jose Perez', 'joseperez@email.com', '1234', 1)
insert into Usuario values('Julio Perro', 'lic1@email.com', '1234', 2)
insert into Usuario values('Rick Sanchez', 'lic2@email.com', '1234', 2)
insert into Usuario values('Bruno Diaz', 'lic3@email.com', '1234', 2)
insert into Usuario values('Pedro Caballo', 'lic4@email.com', '1234', 2)
insert into Usuario values('Se�or Administrador', 'admin@email.com', 1234, 3)

insert into UsuarioMateria values(1, 1)
insert into UsuarioMateria values(1, 2)
insert into UsuarioMateria values(2, 3)
insert into UsuarioMateria values(2, 1)