using AutoMapper;
using iText.Kernel.Pdf.Canvas.Wmf;
using TEKTON.Application.Contracts;
using TEKTON.Application.Dtos.Producto;
using TEKTON.Domain.Aggregates.ProductoAgg;
using TEKTON.Infrastructure.Crosscutting.ExceptionsTypes;
using TEKTON.Infrastructure.Crosscutting.Resources;

namespace TEKTON.Application.Implementations
{
    public class ProductoAppService : IProductoAppService
    {
        private IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public ProductoAppService(IProductoRepository productoRepository, IMapper mapper) 
        {
            this._productoRepository = productoRepository;
            this._mapper = mapper;
        }

        public async Task<ProductoListarResponseDto> InicializarProductos()
        {
            ProductoListarResponseReadOnly ListaProductos = await this._productoRepository.InicializarProductos();

            if (ListaProductos != null)
            {
                return _mapper.Map<ProductoListarResponseDto>(ListaProductos);
            }
            throw new NotFoundException(Messages.NotFoundResource);
        }

        public async Task<ProductoListarResponseDto> ListarProductos()
        {
            ProductoListarResponseReadOnly ListaProductos = await this._productoRepository.ListarProductos();

            if (ListaProductos != null)
            {
                return _mapper.Map<ProductoListarResponseDto>(ListaProductos);
            }
            throw new NotFoundException(Messages.NotFoundResource);
        }

        public async Task<ProductoResponseDto> BuscarRegistro(int IdProducto)
        {
            if (IdProducto > 0)
            {
                ProductoResponseReadOnly oProducto = await this._productoRepository.BuscarRegistro(IdProducto);

                if (oProducto != null)
                {
                    return _mapper.Map<ProductoResponseDto>(oProducto);
                }
                throw new NotFoundException(Messages.NotFoundResource);
            }

            throw new ArgumentNullException(IdProducto.ToString());
        }

        public async Task<bool> EliminarRegistro(int IdProducto)
        {
            if (IdProducto > 0)
            {
                bool bEstado = await this._productoRepository.EliminarRegistro(IdProducto);

                return bEstado;

                throw new NotFoundException(Messages.NotFoundResource);
            }

            throw new ArgumentNullException(IdProducto.ToString());
        }

        public async Task<int> GrabarRegistro(ProductoRequestDto Producto)
        {
            if (Producto != null)
            {
                ProductoRequestReadOnly FiltroRequest = _mapper.Map<ProductoRequestDto, ProductoRequestReadOnly>(Producto);

                int respuesta = await this._productoRepository.GrabarRegistro(FiltroRequest);

                return respuesta;

                throw new NotFoundException(Messages.NotFoundResource);
            }
            throw new ArgumentNullException(Producto.ToString());
        }

        public async Task<int> ActualizarRegistro(ProductoRequestDto Producto)
        {
            if (Producto != null)
            {
                ProductoRequestReadOnly FiltroRequest = _mapper.Map<ProductoRequestDto, ProductoRequestReadOnly>(Producto);

                int respuesta = await this._productoRepository.ActualizarRegistro(FiltroRequest);

                return respuesta;

                throw new NotFoundException(Messages.NotFoundResource);
            }
            throw new ArgumentNullException(Producto.ToString());
        }

    }
}
