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

idpais varchar(3) primary key check (idpais LIKE '[a-z][a-z][a-z]'),

nombre varchar(50) not null

)

go

create table ciudad(

idciudad varchar(3) not null check (idciudad LIKE '[a-z][a-z][a-z]'),

idpais varchar(3) foreign key references pais not null,

nombre varchar(50) not null,

constraint PK_ciudad primary key (idciudad,idpais)

)

go

create table usuario(

logid varchar(50) primary key,

contrasena varchar(50) not null,

nombre varchar(50) not null,

apellido varchar(50) not null

)

go

create table pronostico(

codigo int identity primary key,

idciudad varchar(3) not null,

idpais varchar(3) not null,

constraint FK_pronostico foreign key (idciudad,idpais) references ciudad(idciudad,idpais),

creador varchar(50) foreign key references usuario(logid) not null,

fecha datetime not null,

temperaturamax int not null,

temperaturamin int not null,

velocidadviento int not null check(velocidadviento >=0),

tipocielo varchar(30) not null,

problluvia int not null check (problluvia between 0 AND 100),

constraint chk_cielo check (tipocielo in ('nuboso','parcialmente nuboso', 'despejado')),

check (temperaturamax >=temperaturamin)

)



GO

--listar pronosticos del dia--

CREATE PROC PronosticosDelDia

AS

IF NOT EXISTS (SELECT * FROM pronostico WHERE pronostico.fecha = getdate())

RETURN -1 -- no hay pronosticos del dia

ELSE

BEGIN

SELECT * FROM pronostico WHERE fecha = getdate()

END

GO

--pronosticos por ciudad--

CREATE PROC ListarPxCiudad

@idciudad varchar(3), @idpais varchar(3)

AS

BEGIN

IF NOT EXISTS (SELECT * FROM pais WHERE pais.idpais = @idpais)

RETURN -1 ---el pais no existe en el sistema

IF NOT EXISTS (SELECT * FROM ciudad WHERE ciudad.idciudad = @idciudad AND ciudad.idpais = @idpais)

RETURN -2 --la ciudad no existe en el sistema

IF NOT EXISTS (SELECT * FROM pronostico WHERE pronostico.idpais = @idpais AND pronostico.idciudad = @idciudad)

RETURN -3 --no existen pronosticos asociados a la ciudad

ELSE

SELECT * FROM pronostico WHERE pronostico.idpais = @idpais AND pronostico.idciudad = @idciudad

END

GO

--listar ciudades--

CREATE PROC ListarCiudad

AS

BEGIN

SELECT * FROM ciudad

END

GO

--listar paises--

CREATE PROC ListarPais

AS

BEGIN

SELECT * FROM pais

END

GO

--AltaPais--

CREATE PROC AltaPais

@idpais varchar(3),

@nombre varchar(50)

AS

IF EXISTS (SELECT * FROM pais WHERE pais.idpais = @idpais)

RETURN -1 --Ya existe un pais con el mismo codigo

ELSE

BEGIN TRAN

INSERT INTO pais (idpais,nombre)

VALUES(@idpais,@nombre)

IF @@ERROR != 0

BEGIN

ROLLBACK TRAN

RETURN -2 --error al ingresarse el pais

END

ELSE

BEGIN

COMMIT TRAN

RETURN 1 -- se ingreso correctamente

END

GO

--Modificar Pais--

CREATE PROC ModificarPais

@idpais varchar(3),

@nombre varchar(50)

AS

IF NOT EXISTS(SELECT * FROM pais WHERE pais.idpais = @idpais)

RETURN -1 --el pais no existe

ELSE

BEGIN

UPDATE pais SET nombre = @nombre WHERE pais.idpais = @idpais

IF @@ERROR != 0

RETURN -2 --Hubo un error al modificarse el pais

ELSE

RETURN 1 --Modificaciones exitosa

END

GO

--AltaCiudad--

CREATE PROC AltaCiudad

@idciudad varchar(3),

@idpais varchar(3),

@nombre varchar(50)

AS

IF EXISTS (SELECT * FROM ciudad WHERE ciudad.idpais = @idpais AND ciudad.idciudad = @idciudad)

RETURN -1 --Ya existe una ciudad con el mismo codigo

ELSE

BEGIN TRAN

INSERT INTO ciudad (idciudad,idpais,nombre)

VALUES(@idciudad,@idpais,@nombre)

IF @@ERROR != 0

BEGIN

ROLLBACK TRAN

RETURN -2 --error al ingresarse la ciudad

END

ELSE

BEGIN

COMMIT TRAN

RETURN 1 -- se ingreso correctamente

END

GO

--Modificar Ciudad--

CREATE PROC ModificarCiudad

@idciudad varchar(3),

@idpais varchar(3),

@nombre varchar(50)

AS

IF NOT EXISTS(SELECT * FROM ciudad WHERE ciudad.idpais = @idpais AND ciudad.idciudad = @idciudad)

RETURN -1 --la ciudad no existe

ELSE

BEGIN

UPDATE ciudad SET nombre = @nombre WHERE ciudad.idpais = @idpais AND ciudad.idciudad = @idciudad

IF @@ERROR != 0

RETURN -2 --Hubo un error al modificarse la ciudad

ELSE

RETURN 1 --la modificacion se realizo con exito

END

GO

--Alta Usuario--

CREATE PROC AltaUsuario

@logid varchar(50),

@contrasena varchar(50),

@nombre varchar(50),

@apellido varchar(50)

AS

IF EXISTS(SELECT * FROM usuario WHERE usuario.logid = @logid)

RETURN -1 --el usuario ya existe

ELSE

BEGIN TRAN

INSERT INTO usuario (logid,contrasena,nombre,apellido)

VALUES(@logid,@contrasena,@nombre,@apellido)

IF @@ERROR != 0

BEGIN

ROLLBACK TRAN

RETURN -2 --error al ingresarse el usuario

END

ELSE

BEGIN

COMMIT TRAN

RETURN 1 -- se ingreso correctamente

END

GO

--Modificar Usuario--

CREATE PROC ModificarUsuario

@logid varchar(50),

@contrasena varchar(50),

@nombre varchar(50),

@apellido varchar(50)

AS

IF NOT EXISTS(SELECT * FROM usuario WHERE usuario.logid = @logid)

RETURN -1 --el usuario no existe

ELSE

BEGIN

UPDATE usuario SET contrasena = @contrasena, nombre = @nombre, apellido = @apellido WHERE usuario.logid = @logid

IF @@ERROR != 0

RETURN -2 --Hubo un error al modificarse el usuario

ELSE

RETURN 1 --Modificaciones exitosa

END

GO

--Eliminar Usuario--

CREATE PROC EliminarUsuario

@logid varchar(50)

AS

IF NOT EXISTS(SELECT * FROM usuario WHERE usuario.logid = @logid)

RETURN -1 --el usuario no existe

ELSE

BEGIN

DELETE FROM usuario WHERE usuario.logid = @logid

IF @@ERROR != 0

RETURN -2 --error al eliminarse el usuario

ELSE

BEGIN

RETURN 1 --usuario eliminado con exito

END

END

GO

--Alta Pronostico--

CREATE PROC AltaPronostico

@idciudad varchar(3),

@idpais varchar(3),

@creador varchar(50),

@fecha datetime,

@temperaturamax int,

@temperaturamin int,

@velocidadviento int,

@tipocielo varchar(30),

@problluvia int

AS

INSERT INTO pronostico(idciudad,idpais,creador,fecha,temperaturamax,temperaturamin,velocidadviento,tipocielo,problluvia)

VALUES(@idciudad,@idpais,@creador,@fecha,@temperaturamax,@temperaturamin,@velocidadviento,@tipocielo,@problluvia)

IF @@ERROR != 0

RETURN -1 --Error en el alta del pronostico

ELSE

BEGIN

RETURN 1 --alta realizada con exito

END

GO

--Eliminar ciudad--

CREATE PROC EliminarCiudad

@idciudad varchar(3),

@idpais varchar(3)

AS

IF NOT EXISTS(SELECT * FROM ciudad WHERE ciudad.idciudad = @idciudad AND ciudad.idpais = @idpais)

RETURN -1 --No existe la ciudad

BEGIN TRAN

IF EXISTS( SELECT * from pronostico WHERE pronostico.idciudad = @idciudad AND pronostico.idpais = @idpais)

DELETE pronostico WHERE pronostico.idciudad = @idciudad AND pronostico.idpais = @idpais

IF @@ERROR != 0

BEGIN

ROLLBACK TRAN

RETURN -2 --Error al eliminar pronostico

END

DELETE ciudad WHERE ciudad.idciudad = @idciudad AND ciudad.idpais = @idpais

IF @@ERROR != 0

BEGIN

ROLLBACK TRAN

RETURN -3 --Error al eliminar pronostico

END

ELSE

BEGIN

COMMIT TRAN

RETURN 1 --Eliminacion exitosa

END

GO

--Eliminar Pais--

CREATE PROC EliminarPais

@idpais varchar(3)

AS

IF NOT EXISTS(SELECT * FROM pais WHERE pais.idpais = @idpais)

RETURN -1 --No existe el pais

IF EXISTS(SELECT * FROM pronostico WHERE pronostico.idpais = @idpais)

RETURN -2 --El pais tiene pronosticos asociados

BEGIN TRAN

DELETE ciudad WHERE ciudad.idpais = @idpais

IF @@ERROR != 0

BEGIN

ROLLBACK TRAN

RETURN -3 --Error al eliminar la ciudad

END

DELETE pais WHERE pais.idpais = @idpais

IF @@ERROR != 0

BEGIN

ROLLBACK TRAN

RETURN -4 --Error al eliminar el pais

END

ELSE

BEGIN

COMMIT TRAN

RETURN 1 --Pais eliminado con exito

END

GO




--Listar ciudades por paises

CREATE PROC ListarCiudadxPais

@idpais varchar(3)

AS
BEGIN

SELECT * FROM ciudad WHERE idpais = @idpais

END

GO

--Logueo usuario

CREATE PROC Logueo

@logid varchar(50),

@contrasena varchar(50)

AS

BEGIN

IF NOT EXISTS(SELECT * FROM usuario WHERE logid = @logid)

RETURN -1 --no existe usuario

IF NOT EXISTS (SELECT * FROM usuario WHERE logid = @logid AND contrasena = @contrasena)

RETURN -2 --datos de ingreso invalidos

ELSE

RETURN 1 --logueo exitoso

END

GO

--Chequeo de pronosticos por usuario

CREATE PROC ChequeoPronosticoxUsuario

@logid varchar(50)

AS

BEGIN

IF EXISTS (SELECT * FROM pronostico WHERE creador = @logid)

RETURN 1 --existen pronosticos asociados al usuario

ELSE

RETURN -1 --no existen pronosticos asociados al usuario

END

GO
--Buscar Pais
CREATE PROC BuscarPais
@idpais varchar(3)
AS
BEGIN
SELECT * FROM pais WHERE idpais = @idpais
END

GO
--Buscar Usuario
CREATE PROC BuscarUsuario
@logId varchar(50)
AS
BEGIN
	SELECT * FROM usuario WHERE usuario.logid = @logId;
END

GO


Insert into pais (idpais,nombre) values ('URU','Uruguay')

select * from pais