using NetCoreApi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Data.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllProductos();
        Task<Producto> GetProductoDetails(int id);
        Task<bool> InsertProducto(Producto producto);
        Task<bool> UpdateProducto(Producto producto);
        Task<bool> DeleteProducto(Producto producto);
        Task<bool> ExistProducto(int id);

    }
}
