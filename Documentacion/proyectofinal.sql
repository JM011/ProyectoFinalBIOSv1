use master
if exists(select * from SysDataBases where name = 'proyectofinal')
begin 
drop database proyectofinal
end
go

create database proyectofinal 

go
use proyectofinal 
go
create table pais(
idpais varchar(3) primary key,
nombre varchar(50) not null
)
go
create table ciudad(
idciudad varchar(3) not null,
idpais varchar(3) foreign key references pais not null,
nombre varchar(50) not null,
constraint PK_ciudad primary key (idciudad,idpais)
)
go
create table usuario(
logid varchar(50) primary key,
contrasena varchar(50) not null,
nombre varchar(50),
apellido varchar(50)
)
go
create table pronostico(
codigo int identity primary key,
idciudad varchar(3) not null,
idpais varchar(3) not null,
constraint FK_pronostico foreign key (idciudad,idpais) references ciudad(idciudad,idpais),
creador varchar(50) foreign key references usuario(logid) not null,
fecha datetime,
temperaturamax int,
temperaturamin int,
velocidadviento int,
tipocielo varchar(30),
problluvia int,
constraint chk_cielo check (tipocielo in ('nuboso','parcialmente nuboso', 'despejado')
)
)

