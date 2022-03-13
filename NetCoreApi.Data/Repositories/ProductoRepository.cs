using Microsoft.EntityFrameworkCore;
using NetCoreApi.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductosDBContext _context;
        public ProductoRepository(ProductosDBContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteProducto(Producto producto)
        {
            producto.Disabled = 1;
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            return await _context.Productos.Where(x => !x.Disabled.Equals(1)).Select(
                        x => new Producto
                        {
                            Id = x.Id,
                            Nombre = x.Nombre,
                            ValorUnitario = x.ValorUnitario,
                        }
                        ).ToListAsync();
        }

        public async Task<Producto> GetProductoDetails(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.Disabled.Equals(1));
        }

        public async Task<bool> InsertProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistProducto(int id)
        {
            return await _context.Productos.AnyAsync(x => x.Id.Equals(id) && !x.Disabled.Equals(1));
        }
    }
}
