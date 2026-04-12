public class NotificacionPush: Notificacion
{
    public int DispositivoId {get; set;}


    public NotificacionPush(string remitente, DateTime fechaenvio, int disId): base(remitente, fechaenvio)
    {
        DispositivoId = disId;
    }

    public override bool Enviar(string destinatario, string msj)
    {
        Destinatario = destinatario;
        Msj = msj;
        return true;
    }

    public override string ObtenerTipo()
    {
        return "Push";
    }
}