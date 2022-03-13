using NetCoreApi.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Services
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetAllProductos();
        Task<ProductoDto> GetProductoDetails(int id);
        Task<bool> InsertProducto(ProductoDto producto);
        Task<bool> UpdateProducto(int id, ProductoDto producto);
        Task<bool> DeleteProducto(int id);
    }
}
