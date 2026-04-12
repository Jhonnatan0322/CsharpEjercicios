


    async Task<string> SimularConsultaBD(string tabla)
    {
        await Task.Delay(2000);
        return $"Datos de {tabla} listos";
    }

    async Task<string> SimularConsultaAPI(string endpoint)
    {
        await Task.Delay(1000);
        return $"Respuesta de {endpoint} recibida";
    }

/*     string resultado = await SimularConsultaBD("SIVA");
    Console.WriteLine(resultado);

    string resultado2 = await SimularConsultaAPI("SIVA2");
    Console.WriteLine(resultado2); */

var cronometro = System.Diagnostics.Stopwatch.StartNew(); // ← arranca ANTES

Task<string> tarea1 = SimularConsultaBD("clientes");
Task<string> tarea2 = SimularConsultaAPI("productos");
Task<string> tarea3 = SimularConsultaAPI("endpoint3");
string[] resultados = await Task.WhenAll(tarea1, tarea2, tarea3);

cronometro.Stop(); // ← para DESPUÉS de que terminen

Console.WriteLine(resultados[0]);
Console.WriteLine(resultados[1]);
Console.WriteLine(resultados[2]);
Console.WriteLine($"Tiempo total: {cronometro.Elapsed.TotalSeconds:F1} segundos");
