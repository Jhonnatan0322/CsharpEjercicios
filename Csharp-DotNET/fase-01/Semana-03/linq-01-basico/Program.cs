
var productos = new List<Producto>
{
    new Producto { Nombre = "Laptop",     Categoria = "Electronica", Precio = 3500000, Stock = 10, Activo = true  },
    new Producto { Nombre = "Mouse",      Categoria = "Electronica", Precio = 85000,   Stock = 50, Activo = true  },
    new Producto { Nombre = "Escritorio", Categoria = "Muebles",     Precio = 950000,  Stock = 0,  Activo = true  },
    new Producto { Nombre = "Silla",      Categoria = "Muebles",     Precio = 750000,  Stock = 8,  Activo = false },
    new Producto { Nombre = "Teclado",    Categoria = "Electronica", Precio = 120000,  Stock = 30, Activo = true  },
    new Producto { Nombre = "Lampara",    Categoria = "Muebles",     Precio = 180000,  Stock = 15, Activo = true  },
    new Producto { Nombre = "Monitor",    Categoria = "Electronica", Precio = 980000,  Stock = 0,  Activo = true  },
    new Producto { Nombre = "Webcam",     Categoria = "Electronica", Precio = 210000,  Stock = 12, Activo = false },
};



var ActivosYconStock = productos.Where(p => p.Activo && p.Stock > 0).Select(p => p.Nombre+" - "+p.Stock);
System.Console.WriteLine("================================================");
foreach (var item in ActivosYconStock)
{
    System.Console.WriteLine(item);
}

var productosElectronica = productos.Where(p => p.Categoria=="Electronica").OrderByDescending(p => p.Precio).Select(p=> p.Nombre+"-"+p.Precio);
System.Console.WriteLine("================================================");
foreach (var item in productosElectronica)
{
    System.Console.WriteLine(item);
}


var precioPromedioCategoria = productos.GroupBy(p => p.Categoria).Select(g => new
{
    Categoria = g.Key,
    Promedio = g.Average(p => p.Precio)
});
System.Console.WriteLine("================================================");
foreach (var item in precioPromedioCategoria)
{
    System.Console.WriteLine(item.Categoria +"-"+item.Promedio);
}

var productoMasCaro = productos.OrderByDescending(p=> p.Precio).Select(p=> p.Nombre).FirstOrDefault();
System.Console.WriteLine("================================================");
System.Console.WriteLine(productoMasCaro);

System.Console.WriteLine("================================================");
var ExisteProdSinStock = productos.Any(p => p.Stock == 0);
System.Console.WriteLine(ExisteProdSinStock);


public class Producto
{
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public bool Activo { get; set; }
}



