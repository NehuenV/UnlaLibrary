insert into Carrera values ('Licenciatura en Sistemas'); 
insert into Carrera values ('Diseño y comunicacion visual'); 
insert into Carrera values ('Ingenieria en Sistemas'); 

insert into Idioma values ('Ingles'); 
insert into Idioma values ('Español'); 

insert into Materia values ('Matematica 1'); 
insert into Materia values ('Programacion en computadoras'); 
insert into Materia values ('Diseño 1 '); 
insert into Materia values ('Fisica'); 

insert into TipoUsuario values ('Administrador'); 
insert into TipoUsuario values ('Profesor'); 
insert into TipoUsuario values ('Alumno'); 

insert into CarreraMateria values (1,1); 
insert into CarreraMateria values (1,2); 
insert into CarreraMateria values (2,3); 
insert into CarreraMateria values (3,4); 


insert into Universidad values ('Universidad Nacional de Lanus'); 
insert into Universidad values ('Universidad  de Buenos Aires'); 

insert into UniversidadCarrera values (1,1); 
insert into UniversidadCarrera values (1,2); 
insert into UniversidadCarrera values (2,3); 


insert into Usuario values ('Damian','Santos','22222222','dsantos@mail.com','1234',2);
insert into Usuario values ('Roberto','Garcia','11111111','rgarcia@mail.com','1234',2);
insert into Usuario values ('Laura','Loidi','55555555','lloidi@mail.com','1234',2);
insert into Usuario values ('Damian','Santos','22222222','dsantos@mail.com','1234',2);
insert into Usuario values ('Cristian', 'Villafañe','33333333','cvillafañe@mail.com','1234',3); 
insert into Usuario values ('Claudio', 'Trukula','33333333','cvillafañe@mail.com','1234',3); 
insert into Usuario values ('Nehuen', 'Verges','33333333','nverges@mail.com','1234',3); 
insert into Usuario values ('Admin', 'Admin','44444444','Admin@mail.com','1234',1); 



insert into UsuarioMateria values (1,1); 
insert into UsuarioMateria values (2,2); 
insert into UsuarioMateria values (3,3); 
insert into UsuarioMateria values (4,4); 
insert into UsuarioMateria values (1,5); 
insert into UsuarioMateria values (1,6); 
insert into UsuarioMateria values (2,7);

insert into UsuarioCarreraUniversidad values (1,1,1);
insert into UsuarioCarreraUniversidad values (1,1,2);
insert into UsuarioCarreraUniversidad values (1,1,5);
insert into UsuarioCarreraUniversidad values (1,1,6);
insert into UsuarioCarreraUniversidad values (1,1,7);