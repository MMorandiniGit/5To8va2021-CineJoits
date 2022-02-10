
delimiter $$
use cine $$
drop trigger if exists verificarentrada $$
create trigger verificarentrada before insert on entrada
for each row 
begin

	declare pipe int;
    declare capacidad int;
    
	select count(numero) into pipe
	from entrada
    where idproyeccion = new.idProyeccion; 


    select capacidad into capacidad
    from proyeccion 
    inner join sala on proyeccion.idsala = sala.idSala
    where idproyeccion = new.idproyeccion;
    
	if (capacidad > pipe) then
	    signal sqlstate '45000'
        set message_text = 'sala llena';

	end if;
end$$

DELIMITER $$
use cine $$
DROP TRIGGER IF exists AftPelicula $$
CREATE Trigger AftPelicula AFTER INSERT ON Pelicula
for each row
begin 

        insert into Proyeccion(idSala, idPelicula, fechahora)
        select idSala, new.idPelicula, now()
        from sala;

end$$
