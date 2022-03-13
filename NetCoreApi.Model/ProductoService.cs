using AutoMapper;
using NetCoreApi.Data.Models;
using NetCoreApi.Data.Repositories;
using NetCoreApi.Services.Models;
using System;
using System.Collections.Generic;
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


        public async Task<bool> DeleteProducto(int id)
        {
            var producto = await GetProducto(id);
            return await _productoRepository.DeleteProducto(producto);
        }

        public async Task<List<ProductoDto>> GetAllProductos()
        {
            var result = await _productoRepository.GetAllProductos();
            return _mapper.Map<List<Producto>, List<ProductoDto>>(result);
        }

        public async Task<ProductoDto> GetProductoDetails(int id)
        {
            var producto = await GetProducto(id);
            return _mapper.Map<Producto, ProductoDto>(producto);
        }

        public async Task<bool> InsertProducto(ProductoDto producto)
        {
            return await _productoRepository.InsertProducto(_mapper.Map<ProductoDto, Producto>(producto));
        }

        public async Task<bool> UpdateProducto(int id, ProductoDto producto)
        {
            await ValidateIfExistCliente(id);
            producto.Id = id;
            return await _productoRepository.UpdateProducto(_mapper.Map<ProductoDto, Producto>(producto));
        }

        private async Task<bool> ValidateIfExistCliente(int id)
        {
            var exist = await _productoRepository.ExistProducto(id);
            if (!exist) throw new Exception("No se encontro el producto");
            return exist;
        }

        private async Task<Producto> GetProducto(int id)
        {
            var producto = await _productoRepository.GetProductoDetails(id);
            if (producto == null) throw new Exception("No se encontro el producto");
            return producto;
        }
    }
}
