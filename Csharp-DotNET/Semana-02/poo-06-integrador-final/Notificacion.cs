public abstract class Notificacion: INotificacion
{
    public string Remitente {get; set; }
    public DateTime FechaEnvio { get; set; }
    public string Destinatario { get; set; }
    public string Msj { get; set; }

    public Notificacion(string remitente, DateTime fechaenvio)
    {
        Remitente = remitente;
        FechaEnvio = fechaenvio;
    }

    public void MostrarLog()
    {
        System.Console.WriteLine($"""
        ======================================================
        ASUNTO: {Msj}
        REMITENTE: {Remitente} FECHA: {FechaEnvio}
        TIPO: {ObtenerTipo()}  DESTINTARIO: {Destinatario}   
        ======================================================
        """);
    }

    public abstract bool Enviar(string destinatario, string msj);
    public abstract string ObtenerTipo();
}