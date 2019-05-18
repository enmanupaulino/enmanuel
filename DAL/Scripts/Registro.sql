CREATE DATABASE RegistroDb 
GO


CREATE TABLE Registros( 

 Id int primary key identity  ,

 Nombre varchar (50),
 Email varchar (30),
 NivelUsuario varchar (1),
 Usuario varchar (25)  unique ,
 Clave varchar (15),
 FechaIngreso Datetime,
 FechaRegistro Datetime

)