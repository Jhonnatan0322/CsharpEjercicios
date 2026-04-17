-- traer todos los usuarios que tiene prestamos activos actualmente
select u.nombre from usuarios u 
inner join prestamos p on p.usuarioid = u.id 
where p.activo = true;

--Traer cuántos préstamos ha hecho cada usuario 
-- — incluyendo los que no tienen ninguno

select u.nombre,count(p.id)
from usuarios u 
left join prestamos p on p.usuarioid  = u.id 
group by u.nombre  


3-- traer libro mas prestado
select l.nombre,count(p.id) from prestamos p 
inner join libros l on l.id = p.libroid 
group by l.nombre
order by count(p.id)
limit 1

--Traer los libros que nunca han sido prestados
select l.nombre  from libros l 
left join prestamos p on l.id = p.libroid 
where p.id is null

--Traer los préstamos de los últimos 30 días con nombre de libro y usuario
select l.nombre as "Libro",u.nombre as "usuario" from prestamos p 
inner join libros l on l.id = p.libroid 
inner join usuarios u on u.id = p.usuarioid 
where p.fecha_prestamo >= CURRENT_DATE - interval '30 days'
 