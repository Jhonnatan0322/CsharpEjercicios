
var clientes = new List<Cliente>
{
    new Cliente { Id = 1, Nombre = "Jhonnatan", Ciudad = "Barranquilla" },
    new Cliente { Id = 2, Nombre = "María",     Ciudad = "Bogotá"       },
    new Cliente { Id = 3, Nombre = "Carlos",    Ciudad = "Medellín"     },
    new Cliente { Id = 4, Nombre = "Lucía",     Ciudad = "Barranquilla" },
};

var pedidos = new List<Pedido>
{
    new Pedido { Id = 1, ClienteId = 1, Total = 350000,  Fecha = DateTime.Now.AddDays(-5),  Entregado = true  },
    new Pedido { Id = 2, ClienteId = 1, Total = 120000,  Fecha = DateTime.Now.AddDays(-2),  Entregado = false },
    new Pedido { Id = 3, ClienteId = 2, Total = 890000,  Fecha = DateTime.Now.AddDays(-10), Entregado = true  },
    new Pedido { Id = 4, ClienteId = 3, Total = 45000,   Fecha = DateTime.Now.AddDays(-1),  Entregado = false },
    new Pedido { Id = 5, ClienteId = 4, Total = 670000,  Fecha = DateTime.Now.AddDays(-3),  Entregado = true  },
    new Pedido { Id = 6, ClienteId = 2, Total = 230000,  Fecha = DateTime.Now.AddDays(-7),  Entregado = false },
    new Pedido { Id = 7, ClienteId = 1, Total = 980000,  Fecha = DateTime.Now.AddDays(-15), Entregado = true  },
    new Pedido { Id = 8, ClienteId = 4, Total = 150000,  Fecha = DateTime.Now.AddDays(-4),  Entregado = false },
};

// ejercicio 1
var pedidosEntregados = pedidos.Where(p => !p.Entregado).Join(clientes,
x => x.ClienteId,
y => y.Id,
(x,y) => new
{
    Pedido = x.Id,
    ncliente = y.Nombre
}
);
System.Console.WriteLine("****************************************************");
foreach (var item in pedidosEntregados)
{
    System.Console.WriteLine(item.Pedido+" - "+item.ncliente);
}
//ejercicio 2
System.Console.WriteLine("****************************************************");
//var totalGastadoPorCliente = pedidos.GroupBy(p => p.ClienteId).Select(g => new
//{
//    clienteId = g.Key,
//    total = g.Sum(p => p.Total)
//});

var totalGastadoPorCliente = pedidos.GroupBy(p => p.ClienteId).Join(clientes,
x => x.Key,
y => y.Id,
(x,y) => new
{
    
    Cliente = y.Nombre,
    total = x.Sum(p => p.Total)
}
);

foreach (var item in totalGastadoPorCliente)
{
    System.Console.WriteLine(item);
}

// ejercicio 3
System.Console.WriteLine("****************************************************");
var BquillaPendientes = clientes.Where(c => c.Ciudad == "Barranquilla" && pedidos.Any(p=> p.ClienteId == c.Id && !p.Entregado)).Join(pedidos.Where(p => !p.Entregado),
x => x.Id,
y => y.ClienteId,
(x,y) => new
{
    Cliente = x.Nombre,
    Pedido = y.Id
    
});

foreach (var item in BquillaPendientes)
{
    System.Console.WriteLine($"Pedido:{item.Pedido}  Cliente:{item.Cliente} ");
}

//ejercicio 4
System.Console.WriteLine("****************************************************");
var pedRecienteCliente = pedidos.OrderByDescending(p=> p.Fecha).GroupBy(p=> p.ClienteId).Select(g => new
{
    ClienteId = g.Key,
    Pedido = g.First().Id,
    Fecha = g.First().Fecha
});

foreach (var item in pedRecienteCliente)
{
    System.Console.WriteLine(item);
}