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
        public async Task<List<ClienteDto>> GetAllClientes()
        {
            var result = await _clienteRepository.GetAllClientes();
            return _mapper.Map<List<ClienteDto>>(result);
        }

        public async Task<ClienteDto> GetClienteDetails(int id)
        {
            var cliente = await GetCliente(id);
            return _mapper.Map<Cliente, ClienteDto>(cliente);
        }

        public async Task<bool> InsertCliente(ClienteDTO cliente)
        {
            return await _clienteRepository.InsertCliente(_mapper.Map<ClienteDTO, Cliente>(cliente));
        }

        public async Task<bool> UpdateCliente(int id, ClienteDTO cliente)
        {
            await ValidateIfExistCliente(id);
            cliente.Id = id;
            return await _clienteRepository.UpdateCliente(_mapper.Map<ClienteDTO, Cliente>(cliente));
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await GetCliente(id);
            return await _clienteRepository.DeleteCliente(cliente);
        }

        private async Task<bool> ValidateIfExistCliente(int id)
        {
            var exist = await _clienteRepository.ExistCliente(id);
            if (!exist) throw new Exception("No se encontro el cliente");
            return exist;
        }

        private async Task<Cliente> GetCliente(int id)
        {
            var cliente = await _clienteRepository.GetClienteDetails(id);
            if (cliente == null) throw new Exception("No se encontro el cliente");
            return cliente;
        }
    }
}
