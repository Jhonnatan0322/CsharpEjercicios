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

insert into ordenesdetalle (cantidad,precio,orden_id,producto_id) values (2,600000,1,4)
insert into ordenesdetalle (cantidad,precio,orden_id,producto_id) values (1,200000,1,3)

insert into ordenesdetalle (cantidad,precio,orden_id,producto_id) values (2,49500,3,1)
insert into ordenesdetalle (cantidad,precio,orden_id,producto_id) values (1,37500,3,2)

select * from ordenes

-- =============================================================================================================
--ejercicios pos insercion
-- =============================================================================================================

-- 1.Traer todas las órdenes con el nombre del cliente y la fecha
select o.id as "ordenid",c.nombre as "cliente",o.fecha  from ordenes o 
inner join clientes c on c.id = o.cliente_id 

--2.Traer el detalle de la orden 1 — nombre del producto, cantidad y precio

select p.nombre as "Producto",o.cantidad,o.precio from ordenesdetalle o 
inner join productos p on p.id  = o.producto_id 
where o.orden_id =1

-- 3.Traer el total de cada orden — suma de cantidad * precio por orden

select o.orden_id as "Nro Orden",sum(o.cantidad * o.precio) as "Total" 
from ordenesdetalle o 
group by o.orden_id 
order by o.orden_id  asc

-- 4.Traer los productos más vendidos — ordenados por cantidad total vendida
select p.nombre as "Producto" from ordenesdetalle o
inner join productos p on p.id = o.producto_id 
group by p.nombre  
order by SUM(o.cantidad) desc
