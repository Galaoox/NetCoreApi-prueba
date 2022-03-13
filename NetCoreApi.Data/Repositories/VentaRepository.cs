using Microsoft.EntityFrameworkCore;
using NetCoreApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Data.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        public readonly ProductosDBContext _context;

        public VentaRepository(ProductosDBContext context)
        {
            _context = context;
        }

        public async Task<List<Venta>> GetAllVentas()
        {
            return await _context.Ventas.Where(x => !x.Disabled.Equals(1)).Select(
                x => new Venta
                {
                    Id = x.Id,
                    Cantidad = x.Cantidad,
                    ValorTotal = x.ValorTotal,
                    ValorUnitario = x.ValorUnitario,
                    Producto = new Producto
                    {
                        Nombre = x.Producto.Nombre
                    },
                    Cliente = new Cliente
                    {
                        Nombre = x.Cliente.Nombre,
                        Apellido = x.Cliente.Apellido,
                        Cedula = x.Cliente.Cedula,
                        Telefono = x.Cliente.Telefono
                    }
                }
                ).ToListAsync();
        }

        public async Task<Venta> GetVentaDetails(int id)
        {
            return await _context.Ventas.FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.Disabled.Equals(1));
        }
        public async Task<bool> InsertVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVenta(Venta venta)
        {
            venta.Disabled = 1;
            _context.Ventas.Update(venta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Venta> GetVentaDetails(long id)
        {
            return await _context.Ventas.FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.Disabled.Equals(1));
        }
    }
}
