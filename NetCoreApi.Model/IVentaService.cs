using NetCoreApi.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Services
{
    public interface IVentaService
    {
        Task<List<VentaDto>> GetAllVentas();
        Task<bool> InsertVenta(VentaDto venta);
        Task<bool> DeleteVenta(long id);
    }
}
