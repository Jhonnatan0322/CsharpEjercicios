public class NotificacionEmail: Notificacion
{
    string AsuntoEmail { get; set; }


    public NotificacionEmail(string remitente, DateTime fechaenvio,string asunto)
    :base(remitente,fechaenvio)
    {
        AsuntoEmail = asunto;
    }

    public override bool Enviar(string destinatario, string msj)
    {
        Destinatario = destinatario;
        Msj = msj;
        if (destinatario.Contains("@"))
        {
            return true;
        }
        return false;
    }

    public override string ObtenerTipo()
    {
        return "Email";
    }
}