using NetCoreApi.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Services
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>> GetAllClientes();
        Task<ClienteDTO> GetClienteDetails(int id);
        Task<bool> InsertCliente(ClienteDTO cliente);
        Task<bool> UpdateCliente(int id, ClienteDTO cliente);
        Task<bool> DeleteCliente(int id);

    }
}
