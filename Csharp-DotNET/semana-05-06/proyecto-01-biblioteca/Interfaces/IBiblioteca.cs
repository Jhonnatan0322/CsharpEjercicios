public interface IBiblioteca
{
    void RegistrarLibro(Libro libro);
    void RegistrarUsuario(Usuario usuario);
    bool PrestarLibro(int libroId, int usuarioId);
    bool DevolverLibro(int libroId);
    List<Libro> ObtenerLibrosDisponibles();
    List<Prestamo> ObtenerPrestamosActivos();
}