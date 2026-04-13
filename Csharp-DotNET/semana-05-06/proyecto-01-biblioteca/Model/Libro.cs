public class Libro
{
    public int Id {get;set;}
    public string Nombre {get;set;}
    public int Año {get; set;}
    public string Editorial {get;set;}
    public bool Disponible {get; set;}


    public Libro(int id,string nombre,int año,string editorial,bool disponible)
    {
        Id = id;
        Nombre = nombre;
        Año = año;
        Editorial = editorial;
        Disponible = disponible;
    }
}