List<Notificacion> noti = new List<Notificacion>
{
    new NotificacionEmail("jhonnatan@mail.com",DateTime.Now,"Primera notificacion email"),
    new NotificacionSMS("Tatan",DateTime.Now,"+57"),
    new NotificacionPush("TEST",DateTime.Now,1)
};


foreach (var item in noti)
{
  
    // Lo correcto — reacciona al resultado
    bool enviado = item.Enviar("zabaxtechnologies.com", "Te damos la bienvenida");
    if(enviado)
        item.MostrarLog();
    else
        Console.WriteLine($"Notificación fallida — destinatario inválido");
}