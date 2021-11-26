/*Se pide hacer los SP para dar de alta todas las entidades (menos
Entrada y Cliente) con el prefijo ‘alta’.*/
DELIMITER $$
create procedure altaPelicula (OUT unidPelicula smallint, ungenero
varchar(45),unafecha date,unnombre varchar(45))
begin
insert into pelicula (genero,fecha,nombre)
values(ungenero,unafecha,unnombre);
set  unidPelicula = LAST_INSERT_ID();
end $$

CREATE PROCEDURE PeliculaPorId(unidPelicula smallint)
BEGIN
    SELECT *
    FROM Pelicula
    Where idPelicula = unidPelicula;
END $$
DELIMITER $$
create procedure altaProyeccion (OUT unidProyeccion smallint,unidsala
tinyint,unidpelicula smallint,unafechahora datetime)
begin
insert into proyeccion (idsala,idpelicula,fechahora)
values (unidsala,unidpelicula,unafechahora);
set unidProyeccion = LAST_INSERT_ID();
end$$

DELIMITER $$

create procedure altaSala (OUT unidsala tinyint, unpiso tinyint, unacapacidad smallint)
begin
insert into sala (piso,capacidad)
values (unpiso,unacapacidad);
set unidsala = LAST_INSERT_ID();
end $$

Create procedure SalaPorId(unidsala tinyint)
BEGIN
    SELECT *
    from sala
    where idSala = unidsala;
end $$
/*Se pide hacer el SP ‘registrarCliente’ que reciba los datos del
cliente.
Es importante guardar encriptada la contraseña del cliente usando
SHA256.*/
DELIMITER $$
create procedure registrarcliente (OUT idCliente smallint,unnombre varchar(45),unapellido
varchar(45),unmail varchar (60),unpass char(64))
begin
insert into cliente (nombre,apellido,mail,pass)
values (unnombre,unapellido,unmail,sha2(unpass,256));
end $$
/*Se pide hacer el SP ‘venderEntrada’ que reciba por parámetro el id de
la función, valor e identificación del cliente.
Pensar en cómo hacer para darle valores consecutivos desde 1 al número
de entrada por función.*/
DELIMITER $$
create procedure venderentrada (unnumero smallint,unidproyeccion
smallint,unidcliente smallint,unvalor decimal(6,2))
begin
declare cantidad int;
select count(numero) into cantidad
from entrada
where idproyeccion = unidproyeccion;
insert into entrada (numero,idproyeccion,idcliente,valor)
values (cantidad +1,unidproyeccion,unidcliente,unvalor);
end $$
/*Realizar el SP ‘top10’ que reciba por parámetro 2 fechas, el SP tiene
que devolver identificador y nombre de la película y la cantidad de
entradas vendidas
para la misma entre las 2 fechas. Ordenar por cantidad de entradas de
mayor a menor.*/
DELIMITER $$

CREATE Procedure TOP10 (in unaFechaUno date, in unaFechaDos date)
begin
select Pelicula.fecha, pelicula.idPelicula, pelicula.fecha,
pelicula.nombre, Entrada.numero
from pelicula
inner join Proyeccion on Proyeccion.idPelicula =
Pelicula.idPelicula
inner join entrada on Entrada.idProyeccion =
Proyeccion.idProyeccion
WHERE fecha BETWEEN unaFechaUno AND unaFechaDos
GROUP BY Entrada.idPelicula
LIMIT 10;
end$$

/*Realizar el SF llamado ‘RecaudacionPara’ que reciba por parámetro un
identificador de película y 2 fechas,
la función tiene que retornar la recaudación de la película entre esas
2 fechas.*/
DELIMITER $$
CREATE FUNCTION RecaudacionPara (unidProyeccion int, unaFechaUno date,
unaFechaDos date) returns decimal(6,2) READS SQL DATA
BEGIN
declare Recaudacion decimal(6,2);
select sum(Entrada.valor) into Recaudacion
from entrada
inner join Proyeccion on Proyeccion.idPelicula =
Entrada.idProyeccion
inner join Pelicula on Pelicula.idPelicula =
Proyeccion.idProyeccion
where entrada.idProyeccion= unidProyeccion
and fecha between unaFechaUno and unaFechaDos;
RETURN Recaudacion;
end$$