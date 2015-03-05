--Ok esto es lo que se me ha ocurrido hasta el momento
--Este codigo no es definitivo y puede ser modificado segun sus sujerencias e ideas
--Tomenlo como un bosquejo hecho a la carrera

--1ro Creamos la base de datos, el nombre lo invente y se puede cambiar
CREATE DATABASE [TEAM{STAR}TER]

USE [TEAM{STAR}TER]

--Esta tabla contendra ina lista de todos los atributos generales que alguien puede tener
CREATE TABLE atributo
(
	atr_id int,
	atr_name varchar(50),			--Nombre del attributo
	str_drescription varchar(200),	--Breve descripcion
	primary key (atr_id) 
)

--Los individuos seran las personas
CREATE TABLE individuo
(
	ind_id int,
	ind_name varchar(50),			--Datos basicos, se pueden agregar mas
	ind_lastName1 varchar(50),		--Tambien se puede hacer una tabla aparte para otro datos mas especificos
	ind_lastName2 varchar(50),
	ind_years int
	primary key (ind_id)
)

--Las opciones con las posibles respuestas al evaluar un atributo/caracteristica de alguien
--Es util cuando no puedes medir cosas con numeros (mucho, poco, bueno, malo, regular)
CREATE TABLE opcion
(
	opc_id int identity(1,1),
	atr_id int,						--id del atributo al que pertenece la opcion
	opc_value varchar(50)			
	primary key (opc_id)
	foreign key (atr_id) references atributo(atr_id) 
)

--El tipo de relacion es solo un listado con todas los posoibles tipos relacionesque se pueden tener
--Ejemplo: Familiar, conocidos, amistades, lo he visto, no se quien es
CREATE TABLE tipoRelacion
(
	tipRe_id int identity(1,1),
	tipRe_type varchar(50),
	tipRe_Description varchar(100)
	primary key (tipRe_id)
)

--Relacion entre 2 individuos y como esta se clasifica
CREATE TABLE relacion
(
	rel_id int identity(1,1),
	tipRe_id int,					--Tipo de relacion
	ind_idIni int,					--Individuo 1
	ind_idFin int,					--Individuo 2
	rel_val float					--Valor numerico de que tambuena es la relacion (el programa lo calculara)
	primary key (rel_id)			
	foreign key (tipRe_id)  references tipoRelacion(tipRe_id), 
	foreign key (ind_idIni) references individuo(ind_id),
	foreign key (ind_idFin) references individuo(ind_id)
)

--Tabla con los registros de las evaluaciones relaizadas
CREATE TABLE evaluacion
(
	eva_id int,						
	ind_idExaminer int,				--Evaluador
	ind_idExamined int,				--Evaluado
	rel_id int,						--Id de la relacion (solo personas relacionadas pueden evaluarse)
	atr_id int,						--id del atributo a evaluar
	eva_value float,				--valor numerico de la evaluacion
	opc_id int null,				--valor no numerico, id de la opcion seleccionada
	eva_date smalldatetime			--fecha de evaluacion
	primary key (eva_id)
	foreign key (ind_idExaminer) references individuo(ind_id),
	foreign key (ind_idExamined) references individuo(ind_id),
	foreign key (rel_id) references relacion (rel_id)
)

--Destrezas con las que cuenta una persona
CREATE TABLE habilidad
(
	hab_id int,
	ind_id int,						--id del individuo
	atr_id int,						--atributo del individuo (responsable, puntual,...,educado)
	hab_FinalValue float			--valor calculado segun las evaluaciones de muchas personas
	primary key (hab_id)
	foreign key (ind_id) references individuo (ind_id),
	foreign key (atr_id) references atributo (atr_id) 
)

--Tipica tabla con los usuarios y contrase�as
CREATE TABLE usuario
(
	usu_id int not null identity(1,1),
	usu_account varchar(50) not null,	--Nombre de usuario
	usu_password varchar(50) not null,	--contrase�a
	usu_level int not null,				--Nivel de privilegios (usuario comun, admin, jefe)
	ind_id int null						--Id del individio
	primary key (usu_id)
	foreign key (ind_id) references individuo (ind_id)
)

/*
Estandar de nombres: como se daran cuenta utilice mayormente las 3 primeras letras de las tablas origen
					para el inicio de los nombres segido de un _ y una palabra  especifica en ingles,
					es solo para facilitar la lectura, escritura y que sea facil de recordar. Si lo desean
					se puede cambiar.
*/