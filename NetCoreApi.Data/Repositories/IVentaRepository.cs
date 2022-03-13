using NetCoreApi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Data.Repositories
{
    public interface IVentaRepository
    {
        Task<List<Venta>> GetAllVentas();
        Task<Venta> GetVentaDetails(long id);
        Task<bool> InsertVenta(Venta venta);
        Task<bool> DeleteVenta(Venta venta);
    }
}
