using System.Text.Json;

public class BibliotecaServicio: IBiblioteca
{
    private List<Libro> _libros = new List<Libro>();
    private List<Usuario> _usuarios = new List<Usuario>();
    private List<Prestamo> _prestamos = new List<Prestamo>();

    public void RegistrarLibro(Libro libro)
    {
        _libros.Add(libro);
    }
    public void RegistrarUsuario(Usuario usuario)
    {
        _usuarios.Add(usuario);
    }
    public bool PrestarLibro(int libroId, int usuarioId)
    {
        var libro = _libros.FirstOrDefault(l => l.Id == libroId);
        if (libro == null) return false;

        var usuario = _usuarios.FirstOrDefault(u => u.Id == usuarioId);
        if(usuario == null) return false;

        if(!libro.Disponible)
            return false;

        var prestamo = new Prestamo
        {
            Id = _prestamos.Count + 1,
            LibroId = libroId,
            UsuarioId = usuarioId,
            FechaPrestamo = DateTime.Now,
            Activo = true
        };
        libro.Disponible = false;

        _prestamos.Add(prestamo);

        return true;
        
    }
    public bool DevolverLibro(int libroId)
    {
        var libro = _libros.FirstOrDefault(l => l.Id == libroId);
        if (libro == null) return false;

        var prestamo = _prestamos.FirstOrDefault(p => p.LibroId == libroId);
        if (prestamo == null) return false;

        if(!libro.Disponible)
        {
            prestamo.FechaDevolucion = DateTime.Now;
            prestamo.Activo = false;
            libro.Disponible = true;
        }
        
        return true;


    }

    
    public List<Libro> ObtenerLibrosDisponibles()
    {
        var obtenerDisponibles = _libros.Where(l => l.Disponible);
        return obtenerDisponibles.ToList();
    }
    public List<Prestamo> ObtenerPrestamosActivos()
    {
        var prestamosActivos = _prestamos.Where(p => p.Activo);
        return prestamosActivos.ToList();
    }

    public void GuardarDatos(string ruta)
    {
        // serializa _libros, _usuarios y _prestamos a JSON
        string JsonLibros = JsonSerializer.Serialize(_libros);
        File.WriteAllText(ruta+"/libros.json",JsonLibros);
        string JsonPrestamos = JsonSerializer.Serialize(_prestamos);
        File.WriteAllText(ruta+"/prestamos.json",JsonPrestamos);
        string JsonUsuarios = JsonSerializer.Serialize(_usuarios);
        File.WriteAllText(ruta+"/usuarios.json",JsonUsuarios);
        
    }

    public void CargarDatos(string ruta)
    {
            // ✅ verifica primero
            if (File.Exists(ruta + "/libros.json"))
            {
                string JsonLibros = File.ReadAllText(ruta + "/libros.json");
                _libros = JsonSerializer.Deserialize<List<Libro>>(JsonLibros);
            }
            if (File.Exists(ruta+"/prestamos.json"))
            {
                string JsonPrestamos = File.ReadAllText(ruta + "/prestamos.json");
                _prestamos = JsonSerializer.Deserialize<List<Prestamo>>(JsonPrestamos);
            }
            if (File.Exists(ruta+"/usuarios.json"))
            {
                string JsonUsuarios = File.ReadAllText(ruta+"/usuarios.json");
                _usuarios = JsonSerializer.Deserialize<List<Usuario>>(JsonUsuarios);
            }

    }


}