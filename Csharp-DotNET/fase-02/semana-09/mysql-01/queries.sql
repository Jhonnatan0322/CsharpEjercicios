-- =============================================================================================================
--insercion de registros:
-- =============================================================================================================
insert into categorias (nombre) values('Ropa')
insert into categorias (nombre) values('Electrónica')

select * from categorias c 

insert into clientes (nombre,email,ciudad) values ('Jhonnatan','jhonnatan@mail.com','Barranquilla')
insert into clientes (nombre,email,ciudad) values ('Julieta','julieta@mail.com','Monteria')
insert into clientes (nombre,email,ciudad) values ('Paula','paula@mail.com','Medellin')

select * from clientes c 


insert into productos (nombre,precio,categoria_id) values ('Camiseta Talla L',49500,1)
insert into productos (nombre,precio,categoria_id) values ('Camisa Talla L',37500,1)
insert into productos (nombre,precio,categoria_id) values ('Tester',200000,2)
insert into productos (nombre,precio,categoria_id) values ('Monitor 27 pulgadas',600000,2)

select * from productos p 

insert into ordenes (cliente_id) values (1)
insert into ordenes (cliente_id) values (3)

select * from ordenes

insert into ordenesdetalle (cantidad,precio,orden_id,producto_id) values (2,600000,1,4);
insert into ordenesdetalle (cantidad,precio,orden_id,producto_id) values (1,200000,1,3);

insert into ordenesdetalle (cantidad,precio,orden_id,producto_id) values (2,49500,2,1);
insert into ordenesdetalle (cantidad,precio,orden_id,producto_id) values (1,37500,2,2);

select * from ordenesdetalle o 



select p.nombre as "Producto" from ordenesdetalle o
inner join productos p on p.id = o.producto_id 
group by p.nombre  
order by SUM(o.cantidad) desc

select * from ordenes o 
where fecha >= now() - interval 30 day
