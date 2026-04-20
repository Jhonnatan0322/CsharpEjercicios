create table Clientes(
Id  serial primary key, 
Nombre varchar(254) not null,
Email varchar(100),
Ciudad varchar(100) 
);


create table Categorias(
Id serial primary key,
Nombre varchar(254) not null
);

create table Productos(
Id serial primary key,
Nombre varchar(254) not null,
Precio decimal(18,2) not null,
Categoria_id int,
constraint fk_categoria foreign key(Categoria_id) references Categorias(Id)
);

create table Ordenes(
Id serial primary key,
Fecha timestamp not null default now(),
Cliente_id int, constraint fk_clientes_ordenes foreign key(Cliente_id) references Clientes(Id)
);

create table OrdenesDetalle(
Id serial primary key,
Cantidad int not null,
Precio decimal(18,2) not null,
Orden_id int, constraint fk_Ordenes foreign key(Orden_id) references Ordenes(Id),
Producto_id int, constraint fk_Productos foreign key(Producto_id) references Productos(Id)
);