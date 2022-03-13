using AutoMapper;
using NetCoreApi.Data.Models;
using NetCoreApi.Services.Models;

namespace NetCoreApi.Profiles
{
    public class VentaProfile : Profile
    {
        public VentaProfile()
        {
            CreateMap<Venta, VentaDto>();
            CreateMap<VentaDto, Venta>();
        }
    }
}
