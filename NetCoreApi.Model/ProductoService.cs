using AutoMapper;
using NetCoreApi.Data.Models;
using NetCoreApi.Data.Repositories;
using NetCoreApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApi.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }


        public Task<bool> DeleteProducto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductoDto>> GetAllProductos()
        {
            throw new NotImplementedException();
        }

        public Task<ProductoDto> GetProductoDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertProducto(ProductoDto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProducto(int id, ProductoDto producto)
        {
            throw new NotImplementedException();
        }

        private async Task<Producto> GetProducto(int id)
        {
            var cliente = await _productoRepository.GetProductoDetails(id);
            if (cliente == null) throw new Exception("No se encontro el producto");
            return cliente;
        }
    }
}
