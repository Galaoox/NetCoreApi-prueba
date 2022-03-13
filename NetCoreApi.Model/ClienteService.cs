using AutoMapper;
using NetCoreApi.Data.Models;
using NetCoreApi.Data.Repositories;
using NetCoreApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;


        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<List<ClienteDTO>> GetAllClientes()
        {
            var result = await _clienteRepository.GetAllClientes();
            return _mapper.Map<List<Cliente>, List<ClienteDTO>>(result);
        }

        public async Task<ClienteDTO> GetClienteDetails(int id)
        {
            var cliente = await GetClient(id);
            return _mapper.Map<Cliente, ClienteDTO>(cliente);
        }

        public async Task<bool> InsertCliente(ClienteDTO cliente)
        {
            return await _clienteRepository.InsertCliente(_mapper.Map<ClienteDTO, Cliente>(cliente));
        }

        public async Task<bool> UpdateCliente(int id, ClienteDTO cliente)
        {
            await GetClient(id);
            cliente.Id = id;
            return await _clienteRepository.UpdateCliente(_mapper.Map<ClienteDTO, Cliente>(cliente));
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await GetClient(id);
            return await _clienteRepository.DeleteCliente(cliente);
        }

        private async Task<Cliente> GetClient(int id)
        {
            var cliente = await _clienteRepository.GetClienteDetails(id);
            if (cliente == null) throw new Exception("No se encontro el cliente");
            return cliente;
        }
    }
}
