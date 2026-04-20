async Task<string> ConsultarUsuario(int id)
{
    await Task.Delay(500);
    
    if (id <= 0)
        throw new ArgumentException("El id debe ser mayor a 0");
        
    if (id > 100)
        throw new Exception($"Usuario {id} no encontrado");
        
    return $"Usuario {id} encontrado";
}

async Task<string> GuardarRegistro(string datos)
{
    await Task.Delay(300);

    if (string.IsNullOrEmpty(datos))
    {
        throw new ArgumentNullException();
    }
    else
    {
        return $"Registro guardado: {datos}";
    }
}



try
{
    var uno = await ConsultarUsuario(-1);
    Console.WriteLine(uno);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error de argumento: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error general: {ex.Message}");
}

try
{
    var dos = await ConsultarUsuario(150);
    Console.WriteLine(dos);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error de argumento: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error general: {ex.Message}");
}

try
{
    var tres = await ConsultarUsuario(5);
    Console.WriteLine(tres);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error de argumento: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error general: {ex.Message}");
}

try
{
    var cuatro = await GuardarRegistro("");
    Console.WriteLine(cuatro);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error de argumento: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error general: {ex.Message}");
}

try
{
    var cinco = await GuardarRegistro("Jhonnatan");
    Console.WriteLine(cinco);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error de argumento: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error general: {ex.Message}");
}




