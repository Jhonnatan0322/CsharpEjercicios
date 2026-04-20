BibliotecaServicio servicio = new BibliotecaServicio();
bool continuar = true;

string rutaDatos = "datos";
Directory.CreateDirectory(rutaDatos);
servicio.CargarDatos(rutaDatos);

while (continuar)
{
    Console.WriteLine("\n=== BIBLIOTECA ===");
    Console.WriteLine("1. Registrar libro");
    Console.WriteLine("2. Registrar usuario");
    Console.WriteLine("3. Prestar libro");
    Console.WriteLine("4. Devolver libro");
    Console.WriteLine("5. Ver libros disponibles");
    Console.WriteLine("6. Ver préstamos activos");
    Console.WriteLine("0. Salir");
    Console.Write("\nElige una opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Id del libro: ");
            int idLibro = int.Parse(Console.ReadLine());

            Console.Write("Nombre del libro: ");
            string  nombre= Console.ReadLine();

            Console.WriteLine("Año del libro: ");
            int año = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Editorial del libro: ");
            string editorial = Console.ReadLine();

            

            Libro NuevoLibro = new Libro(idLibro,nombre,año,editorial,true);
            servicio.RegistrarLibro(NuevoLibro);
            break;
        case "2":
            // pedir datos del usuario y registrarlo
            Console.WriteLine("Ingresar su id:");
            int idusuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresar su Nombre:");
            string nombreUsuario = Console.ReadLine();

            Usuario user = new Usuario(idusuario,nombreUsuario);
            
            servicio.RegistrarUsuario(user);
            break;
        case "3":
            // pedir libroId y usuarioId, prestar
            System.Console.WriteLine("Ingresar id del libro a prestar:");
            int idlibrop = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Ingresar su id:");
            int idusuariop = int.Parse(Console.ReadLine());

            bool prestado = servicio.PrestarLibro(idlibrop,idusuariop);
            Console.WriteLine(prestado ? "Préstamo exitoso" : "No se pudo prestar — libro no disponible o no existe");

            break;
        case "4":
            // pedir libroId, devolver
            if (!int.TryParse(Console.ReadLine(), out int idLibrod))
            {
                Console.WriteLine("Ingresa un número válido");
                break;
            }

            servicio.DevolverLibro(idLibrod);
            break;
        case "5":
            foreach (var item in servicio.ObtenerLibrosDisponibles())
            {
                System.Console.WriteLine("****************************************************");
                System.Console.WriteLine($"""
                LIBROS
                ID: {item.Id}
                NOMBRE: {item.Nombre}
                AÑO: {item.Año}
                EDITORIAL:{item.Editorial}
                ESTA DISPONIBLE:{item.Disponible}
                """);
                System.Console.WriteLine("****************************************************");
            }    
            
            break;
        case "6":
            foreach (var item in servicio.ObtenerPrestamosActivos())
            {
                System.Console.WriteLine("****************************************************");
                System.Console.WriteLine($"""
                PRESTAMOS
                ID: {item.Id}
                USUARIO: {item.UsuarioId}
                FECHA PRESTAMO: {item.FechaPrestamo}
                FECHA DEVOLUCION: {item.FechaDevolucion}
                ESTA ACTIVO: {item.Activo}
                """);
                System.Console.WriteLine("****************************************************");
            }
            
            break;
        case "0":
            servicio.GuardarDatos(rutaDatos);
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;
    }
}