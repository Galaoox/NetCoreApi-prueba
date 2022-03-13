using AutoMapper;
using NetCoreApi.Data.Models;
using NetCoreApi.Data.Repositories;
using NetCoreApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApi.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoRepository _productoRepository;

        private readonly IMapper _mapper;
        public VentaService(IVentaRepository ventaRepository, IMapper mapper, IProductoRepository productoRepository)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
            _productoRepository = productoRepository;
        }

        public async Task<List<VentaDto>> GetAllVentas()
        {
            var result = await _ventaRepository.GetAllVentas();
            return _mapper.Map<List<VentaDto>>(result);
        }

        public async Task<bool> InsertVenta(VentaDto venta)
        {
            var producto = await _productoRepository.GetProductoDetails(venta.IdProducto);
            if (producto == null) throw new Exception("No se encontro el producto seleccionado");
            venta.ValorUnitario = producto.ValorUnitario;
            venta.ValorTotal = venta.ValorUnitario * venta.Cantidad;
            return await _ventaRepository.InsertVenta(_mapper.Map<Venta>(venta));
        }

        public async Task<bool> DeleteVenta(long id)
        {
            var venta = await GetVenta(id);
            return await _ventaRepository.DeleteVenta(venta);
        }

        private async Task<Venta> GetVenta(long id)
        {
            var venta = await _ventaRepository.GetVentaDetails(id);
            if (venta == null) throw new Exception("No se encontro la venta");
            return venta;
        }
    }
}
