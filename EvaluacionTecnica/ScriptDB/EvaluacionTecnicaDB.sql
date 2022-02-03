create database tmp

use tmp

create table Role (
	Id int primary key,
	Nombre varchar(50),
	Usuario_Transaccion varchar(50),
	Fecha_Transaccion DateTime
)

create table Usuario (
	Id int primary key,
	RoleId int, 
	Nombre varchar(50),
	Apellido varchar(200),
	Cedula decimal(19, 2),
	Usuario_Nombre varchar(50),
	Contrasena varchar(40),
	Fecha_Nacimiento DateTime,
	Usuario_Transaccion varchar(50),
	Fecha_Transaccion DateTime,
	foreign key(RoleId) REFERENCES Role(Id)
)

insert into Role (Id, Nombre) values (1, 'ADMIN')
insert into Role (Id, Nombre) values (2, 'DESARROLLADOR')

insert into Usuario (Id, RoleID, Nombre, Apellido, Usuario_Nombre, Contrasena, Cedula, Fecha_Nacimiento) values (1, 1, 'Simetrica', 'Consulting', 'ADMIN', 'ADMIN', 2532252213, '01-01-1990')
insert into Usuario (Id, RoleID, Nombre, Apellido, Usuario_Nombre, Contrasena, Cedula, Fecha_Nacimiento) values (2, 2, 'Manuel', 'Consulting', 'DESARROLLADOR', 'APLICANTE', 0000000000, '02-25-2000')
