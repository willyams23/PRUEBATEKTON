using TEKTON.Application.Dtos.Producto;
using TEKTON.Domain.Aggregates.ProductoAgg;

namespace TEKTON.Application.Contracts
{
    public interface IProductoAppService
    {
        Task<ProductoListarResponseDto> InicializarProductos();
        Task<ProductoListarResponseDto> ListarProductos();
        Task<ProductoResponseDto> BuscarRegistro(int IdProducto);
        Task<bool> EliminarRegistro(int IdProducto);

        Task<int> GrabarRegistro(ProductoRequestDto Producto);
        Task<int> ActualizarRegistro(ProductoRequestDto Producto);
    }
}
