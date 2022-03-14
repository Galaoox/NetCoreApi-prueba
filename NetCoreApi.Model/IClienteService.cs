using NetCoreApi.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Services
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> GetAllClientes();
        Task<ClienteDto> GetClienteDetails(int id);
        Task<bool> InsertCliente(ClienteDto cliente);
        Task<bool> UpdateCliente(int id, ClienteDto cliente);
        Task<bool> DeleteCliente(int id);

    }
}
