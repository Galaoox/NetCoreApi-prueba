using AutoMapper;
using NetCoreApi.Data.Models;
using NetCoreApi.Services.Models;

namespace NetCoreApi.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();


        }
    }
}
