insert into libros (nombre,año,editorial,disponible ) values ('El código Da Vinci',2003,'Planeta',true);
insert into libros (nombre,año,editorial,disponible ) values ('Cien años de soledad',1967,'Sudamericana',true);
insert into libros (nombre,año,editorial,disponible ) values ('Clean Code',2008,'Prentice Hall',true);
insert into libros (nombre,año,editorial,disponible ) values ('El Señor de los Anillos',1954,'Minotauro',true);
insert into libros (nombre,año,editorial,disponible ) values ('Harry Potter',1997,'Salamandra',true);


insert into usuarios (nombre) Values('Jhonnatan');
insert into usuarios (nombre) Values('María');
insert into usuarios (nombre) Values('Carlos');

select * from Libros

select * from Libros order by año asc

select * from Libros where editorial = 'Planeta' or editorial ='Minotauro';


select editorial,count(id) from Libros
group by editorial


insert into Prestamos (libroid,usuarioid) values(1,1)


update Libros set disponible = false where id = 1




select 
p.id as "Id prestamo",
l.nombre as "Libro",
u.nombre as "Usuario"
from prestamos p 
inner join libros l on l.id = p.libroid 
inner join usuarios u on u.id = p.usuarioid 
where p.activo = true