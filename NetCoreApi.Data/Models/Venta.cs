#nullable disable

namespace NetCoreApi.Data.Models
{
    public partial class Venta
    {
        public long Id { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public int IdCliente { get; set; }
        public short Disabled { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
