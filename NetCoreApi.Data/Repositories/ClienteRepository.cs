using Microsoft.EntityFrameworkCore;
using NetCoreApi.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ProductosDBContext _context;
        public ClienteRepository(ProductosDBContext context)
        {
            _context = context;
        }


        public async Task<List<Cliente>> GetAllClientes()
        {
            return await _context.Clientes.Where(x => !x.Disabled.Equals(1)).Select(
                x => new Cliente
                {
                    Id = x.Id,
                    Apellido = x.Apellido,
                    Cedula = x.Cedula,
                    Nombre = x.Nombre,
                    Telefono = x.Telefono
                }
                ).ToListAsync();
        }

        public async Task<Cliente> GetClienteDetails(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.Disabled.Equals(1));
        }

        public async Task<bool> ExistCliente(int id)
        {
            return await _context.Clientes.AnyAsync(x => x.Id.Equals(id) && !x.Disabled.Equals(1));
        }

        public async Task<bool> InsertCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCliente(Cliente cliente)
        {
            cliente.Disabled = 1;
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
