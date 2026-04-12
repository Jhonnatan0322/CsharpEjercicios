public class NotificacionSMS: Notificacion
{
    string CodigoPais { get;set;}

    public NotificacionSMS(string remitente, DateTime fechaenvio, string codpais): base(remitente,fechaenvio)
    {
        CodigoPais= codpais;
    }

    public override bool Enviar(string destinatario, string msj)
    {
        Destinatario = destinatario;
        Msj = msj;
        if(destinatario.Length > 7)
        {
            return true;
        }
        return false;
    }

    public override string ObtenerTipo()
    {
        return "SMS";
    }
}