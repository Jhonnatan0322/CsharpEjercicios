public interface INotificacion
{
    public bool Enviar(string destinatario, string msj);
    public string ObtenerTipo();
}