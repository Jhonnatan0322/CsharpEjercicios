public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public decimal Total { get; set; }
    public DateTime Fecha { get; set; }
    public bool Entregado { get; set; }
}
