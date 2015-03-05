CREATE DATABASE [TEAM{STAR}TER]

USE [TEAM{STAR}TER]


CREATE TABLE atributo
(
	atr_id int,
	atr_name varchar(50),
	str_drescription varchar(200),
	primary key (atr_id) 
)

CREATE TABLE individuo
(
	ind_id int,
	ind_name varchar(50),
	ind_lastName1 varchar(50),
	ind_lastName2 varchar(50),
	ind_years int
	primary key (ind_id)
)

CREATE TABLE opcion
(
	opc_id int identity(1,1),
	atr_id int,
	opc_value varchar(50)
	primary key (opc_id)
	foreign key (atr_id) references atributo(atr_id) 
)

CREATE TABLE evaluacion
(
	eva_id int,
	ind_idExaminer int, --Evaluador
	ind_idExamined int, --Evaluado
	atr_id int,
	eva_value float,
	opc_id int null
	primary key (eva_id)
	foreign key (ind_idExaminer) references individuo(ind_id),
	foreign key (ind_idExamined) references individuo(ind_id)
)

CREATE TABLE relacion
(
	rel_id int,
	ind_idIni int,
	ind_idFin int,
	rel_val float
	primary key (rel_id)
	foreign key (ind_idIni) references individuo(ind_id),
	foreign key (ind_idFin) references individuo(ind_id)
)


CREATE TABLE habilidad
(
	hab_id int,
	ind_id int,
	atr_id int,
	hab_FinalValue float
	primary key (hab_id)
	foreign key (ind_id) references individuo (ind_id),
	foreign key (atr_id) references individuo (ind_id) 
)


CREATE TABLE usuario
(
	usu_id int,
	usu_account varchar(50),
	usu_password varchar(50),
	usu_level int
)

 