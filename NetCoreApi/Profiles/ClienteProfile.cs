using AutoMapper;
using NetCoreApi.Data.Models;
using NetCoreApi.Services.Models;

namespace NetCoreApi.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

        }
    }
}
