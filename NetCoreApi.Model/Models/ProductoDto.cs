namespace NetCoreApi.Services.Models
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }
        public short Disabled { get; set; }
    }
}
