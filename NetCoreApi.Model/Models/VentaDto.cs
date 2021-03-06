namespace NetCoreApi.Services.Models
{
    public class VentaDto
    {
        public long? Id { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public int IdCliente { get; set; }
        public short? Disabled { get; set; }
        public ProductoDto Producto { get; set; }
        public ClienteDto Cliente { get; set; }
    }
}
