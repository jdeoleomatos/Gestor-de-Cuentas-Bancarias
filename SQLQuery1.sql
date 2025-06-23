create database Poo1; 
use Poo1;	

CREATE TABLE usuarios (
    id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre_completo VARCHAR(100) NOT NULL,
    Correo_electronico VARCHAR(100) NOT NULL UNIQUE,
    Carrera VARCHAR(50) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL
	Saldo decimal (18,2); Not Null
);

select * from usuarios;

