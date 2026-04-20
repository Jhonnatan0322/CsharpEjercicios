public class Async
{
    public async Task<string> SimularConsultaBD(string tabla)
    {
        await Task.Delay(2000);
        return $"Datos de {tabla} listos";
    }

    public async Task<string> SimularConsultaAPI(string endpoint)
    {
        await Task.Delay(1000);
        return $"Respuesta de {endpoint} recibida";
    }
}