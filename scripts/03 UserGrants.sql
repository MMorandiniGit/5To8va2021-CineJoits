/*  
Administrador:
    Desde cualquier lado puede ver todas las tablas.
    Desde la terminal donde corre el sistema puede agregar y modificar películas, proyecciones y salas.
*/

DROP USER IF EXISTS 'Administrador'@'%';
CREATE USER 'Administrador'@'%' IDENTIFIED BY 'AdminPass';
GRANT SELECT ON cine.* TO 'Administrador'@'%';
GRANT UPDATE ON cine.pelicula to 'Administrador'@'localhost';
GRANT UPDATE ON cine.proyeccion to 'Administrador'@'localhost';
GRANT INSERT ON cine.salas to 'Administrador'@'localhost';

/*
Cajero: desde la red 10.3.45.xxx puede ver todas las tablas y puede insertar filas nuevas en Entrada.
Cliente: desde cualquier lado puede ver su información personal, entrada, proyección y película.
*/

drop user if exists 'clientes'@'%';
create user 'clientes'@'%' identified by 'passcliente';
grant select on cine.cliente to 'clientes'@'%';

/*
Cajeros
*/

drop user if exists 'cajeros'@'10.3.45.%';
create user 'cajeros'@'10.3.45.%' identified by 'passcajero';
grant insert on entrada to 'cajeros'@'10.3.45.%';
grant select on * to 'cajeros'@'10.3.45.%';