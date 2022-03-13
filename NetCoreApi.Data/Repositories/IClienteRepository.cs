using NetCoreApi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Data.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteDetails(int id);
        Task<bool> InsertCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(Cliente cliente);


    }
}
